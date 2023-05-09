
using System.Dynamic;

namespace CRM_CryptoSystem.DataLayer;

public static class StoredProcedures
{
    public const string Lead_Add = "Lead_Add";
    public const string Lead_Delete = "Lead_Delete";
    public const string Lead_GetAll = "Lead_GetAll";
    public const string Lead_GetAllInfoById = "Lead_GetAllInfoById";
    public const string Lead_GetByEmail = "Lead_GetByEmail";
    public const string Lead_GetById = "Lead_GetById";
    public const string Lead_Update = "Lead_Update";

    public const string Account_Add = "Account_Add";
    public const string Account_Delete = "Account_Delete";
    public const string Account_GetAll = "Account_GetAll";
    public const string Account_GetAllAccountsByLeadId = "Account_GetAllAccountsByLeadId";
    public const string Account_GetById = "Account_GetById";
    public const string Account_Update = "Account_Update";
}
