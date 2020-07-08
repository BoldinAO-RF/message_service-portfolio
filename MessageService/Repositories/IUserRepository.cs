using MessageService.Contract;
using System.Linq;

namespace MessageService.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
    }
}
