using MessageService.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MessageService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsers()
        {
            return _context.Set<User>().AsNoTracking();
        }
    }
}
