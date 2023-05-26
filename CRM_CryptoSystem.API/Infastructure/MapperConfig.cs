using AutoMapper;
using CRM_CryptoSystem.API.Models.Requests;
using CRM_CryptoSystem.API.Models.Responses;
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.DataLayer.Models;

namespace CRM_CryptoSystem.API.Infastructure;

public class MapperConfig : Profile 
{
    public MapperConfig()
    {
        CreateMap<LeadRegistrationRequest, LeadDto>();
        CreateMap<LeadUpdateRequest, LeadDto>();
        CreateMap<LeadDto, LeadAllInfoResponse>();
        CreateMap<LeadDto, LeadMainInfoResponse>();

        CreateMap<TransactionRequest, TransactionRequestModel>();
        CreateMap<TransactionResponseModel, TransactionResponse>();

        CreateMap<TransactionTransferRequest, TransactionTransferRequestModel>();

        CreateMap<AddAccountRequest, AccountDto>();
        CreateMap<AddAccountRequest, UpdateAccountRequest>();
        CreateMap<UpdateAccountRequest, AddAccountRequest>();
        CreateMap<AccountDto, AddAccountRequest>();
        CreateMap<UpdateAccountRequest, AccountDto>();
        CreateMap<AccountDto, AccountResponse>();
        CreateMap<LoginRequest, AdminDto>()
            .ForMember(l => l.Email, s => s.MapFrom(a => a.Email))
            .ForMember(l => l.Password, s => s.MapFrom(a => a.Password));

    }
}
