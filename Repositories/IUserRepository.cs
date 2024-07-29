using System.Threading.Tasks;

namespace ShopManagementBackend.Repositories
{
    public interface IUserRepository<T> : IRepository<T>
    {
        Task<T> GetByUsernameAsync(string username);
    }
}
