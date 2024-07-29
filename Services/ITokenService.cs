using ShopManagementBackend.Models;

namespace ShopManagementBackend.Services
{
    public interface ITokenService
    {
        string CreateToken(TBL_ADMINS admin);
    }
}
