using PassWallet.Core.Interfaces;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DAL.DataContext;
using PassWallet.Infrastructure.DAL.Repositories;

namespace PassWallet.Infrastructure.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Passwords = new PasswordRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        public IPasswordRepository Passwords { get; private set; }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}