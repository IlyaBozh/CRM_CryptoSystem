using CRM_CryptoSystem.API.Enums;
using Microsoft.AspNetCore.Authorization;

namespace CRM_CryptoSystem.API.Infastructure
{
    public class AuthorizeByRoleAttribute : AuthorizeAttribute
    {
        public AuthorizeByRoleAttribute(params Role[] roles) 
        {
            Roles = string.Join(",", roles);
        }
    }
}
