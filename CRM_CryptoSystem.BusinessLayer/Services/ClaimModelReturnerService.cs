
using CRM_CryptoSystem.BusinessLayer.Infrastructure;
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.DataLayer.Enums;
using CRM_CryptoSystem.DataLayer.Models;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class ClaimModelReturnerService
{
    public static ClaimModel ReturnLead(LeadDto lead, string login, string password, ClaimModel claimModel)
    {
        if (lead is not null && login == lead.Email &&
            PasswordHash.ValidatePassword(password, lead.Password) && !lead.IsDeleted)
        {
            claimModel.Role = Role.Lead;
            claimModel.Id = lead.Id;
        }

        return claimModel;
    }

    public static ClaimModel ReturnAdmin(AdminDto admin, string login, string password, ClaimModel claimModel)
    {
        if (admin is not null && login == admin.Email &&
           PasswordHash.ValidatePassword(password, admin.Password) && !admin.IsDeleted)
        {
            claimModel.Role = Role.Admin;
            claimModel.Id = admin.Id;
        }
        return claimModel;
    }
}
