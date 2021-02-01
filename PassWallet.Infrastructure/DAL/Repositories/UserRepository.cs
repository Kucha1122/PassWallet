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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string login)
            => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Login == login));

        public async Task<IEnumerable<User>> BrowseAsync()
        {
            var users = _context.Users.AsEnumerable();

            return await Task.FromResult(users);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await Task.CompletedTask;

        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}