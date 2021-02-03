using System;
using PassWallet.Core.Repositories;

namespace PassWallet.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPasswordRepository Passwords { get; }
        int Complete();
    }
}