using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PassWallet.Core.Entities;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DAL.DataContext;

namespace PassWallet.Infrastructure.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<User> GetAsync(string login)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Login == login);
        }
        
    }
}