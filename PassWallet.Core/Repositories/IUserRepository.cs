using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassWallet.Core.Entities;

namespace PassWallet.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string login);
        Task<IEnumerable<User>> BrowseAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);

    }
}