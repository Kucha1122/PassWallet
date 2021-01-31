using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassWallet.Core.Entities;

namespace PassWallet.Core.Repositories
{
    public interface IPasswordRepository
    {
        Task<Password> GetAsync(Guid id);
        Task<IEnumerable<Password>> BrowseAsync();
        Task AddAsync(Password password);
        Task UpdateAsync(Password password);
        Task DeleteAsync(Password password);
    }
}