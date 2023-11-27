using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Database;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext _context;

        public UserRepository(SqlServerContext context)
        {
            _context = context;
        }

        public List<User> GetList()
        {
            var users = _context
                .Set<User>()
                .ToList();

            return users;
        }
    }
}
