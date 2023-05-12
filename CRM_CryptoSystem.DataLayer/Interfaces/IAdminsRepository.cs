
using CRM_CryptoSystem.DataLayer.Models;

namespace CRM_CryptoSystem.DataLayer.Interfaces;

public interface IAdminsRepository
{
    public Task<int> AddAdmin(AdminDto admin);
    public Task<AdminDto> GetAdminByEmail(string email);
}
