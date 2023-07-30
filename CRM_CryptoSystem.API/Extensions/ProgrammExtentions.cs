using CRM_CryptoSystem.BusinessLayer.Infrastructure;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.BusinessLayer.Services;
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using CRM_CryptoSystem.API.Models.Requests;
using CRM_CryptoSystem.API.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;

namespace CRM_CryptoSystem.API.Extensions;

public static class ProgrammExtentions
{
    public static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM", Version = "v1" });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Authorization: Bearer JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer",
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    Array.Empty<string>()
                },
            });
        });
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder =>
            {
                builder
                .WithOrigins("https://localhost:7097")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));
    }

    public static void AddAuthentications(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = TokenOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = TokenOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = TokenOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountsRepository, AccountsRepository>();
        services.AddScoped<IAccountsService, AccountsService>();
        services.AddScoped<ILeadsRepository, LeadsRepository>();
        services.AddScoped<ILeadsService, LeadsService>();
        services.AddScoped<IAdminsRepository, AdminsRepository>();
/*        services.AddScoped<IAdminsService, AdminsService>();*/
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAccountsRepository, AccountsRepository>();
        services.AddScoped<IAccountsService, AccountsService>();
        services.AddScoped<IHttpService, TransactionStoreClient>();
        services.AddScoped<ITransactionsService, TransactionsService>();
/*        services.AddScoped<IMessageProducer, MessageProducer>();*/
    }

    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(config => config.DisableDataAnnotationsValidation = true);

        services.AddScoped<IValidator<AddAccountRequest>, AddAccountValidator>();
        services.AddScoped<IValidator<UpdateAccountRequest>, UpdateAccountValidator>();
        services.AddScoped<IValidator<LeadRegistrationRequest>, LeadRegistrationValidator>();
        services.AddScoped<IValidator<LeadUpdateRequest>, LeadUpdateValidator>();
    }
}
