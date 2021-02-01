using Microsoft.EntityFrameworkCore;
using PassWallet.Core.Entities;

namespace PassWallet.Infrastructure.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}