using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassWallet.Core.Entities;

namespace PassWallet.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync(string login);
    }
}