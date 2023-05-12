﻿
using CRM_CryptoSystem.BusinessLayer.Exceptions;
using CRM_CryptoSystem.BusinessLayer.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace CRM_CryptoSystem.BusinessLayer.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (NotFoundException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.NotFound, error.Message);
        }
        catch (AccessDeniedException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.Forbidden, error.Message);
        }
        catch (NotUniqueEmailException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.Conflict, error.Message);
        }
        catch (BadGatewayException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.BadGateway, error.Message);
        }
        catch (GatewayTimeoutException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.GatewayTimeout, error.Message);
        }
        catch (RepeatCurrencyException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.Conflict, error.Message);
        }
        catch (RegularAccountRestrictionException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.Conflict, error.Message);
        }
        catch (Exception error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, error.StackTrace);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(new ErrorResult()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }
}
