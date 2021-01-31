using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassWallet.Core.Entities;
using PassWallet.Core.Repositories;

namespace PassWallet.Infrastructure.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}