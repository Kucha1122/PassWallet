using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PassWallet.Core.Entities;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DAL.DataContext;

namespace PassWallet.Infrastructure.DAL.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly AppDbContext _context;

        public PasswordRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Password> GetAsync(Guid id)
            => await Task.FromResult(_context.Passwords.SingleOrDefault(x => x.Id == id));


        public async Task<IEnumerable<Password>> BrowseAsync()
        {
            var passwords = _context.Passwords.AsEnumerable();
            
            return await Task.FromResult(passwords);
        }

        public async Task AddAsync(Password password)
        {
            _context.Passwords.Add(password);
            await _context.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Password password)
        {
            _context.Passwords.Attach(password);
            _context.Entry(password).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Password password)
        {
            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}