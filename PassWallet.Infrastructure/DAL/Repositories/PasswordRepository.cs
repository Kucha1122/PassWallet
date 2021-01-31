using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassWallet.Core.Entities;
using PassWallet.Core.Repositories;

namespace PassWallet.Infrastructure.DAL.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        public Task<Password> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Password>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Password password)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Password password)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Password password)
        {
            throw new NotImplementedException();
        }
    }
}