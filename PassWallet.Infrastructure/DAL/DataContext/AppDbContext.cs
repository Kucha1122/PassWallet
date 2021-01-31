using Microsoft.EntityFrameworkCore;

namespace PassWallet.Infrastructure.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}