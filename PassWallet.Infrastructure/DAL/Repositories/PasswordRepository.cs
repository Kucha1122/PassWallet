using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PassWallet.Core.Entities;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DAL.DataContext;
using PassWallet.Infrastructure.Exceptions;

namespace PassWallet.Infrastructure.DAL.Repositories
{
    public class PasswordRepository : Repository<Password>, IPasswordRepository
    {
        public PasswordRepository(AppDbContext context) 
            : base(context)
        {
        }
        
    }
}