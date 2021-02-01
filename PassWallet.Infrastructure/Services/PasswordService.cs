using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassWallet.Infrastructure.DTO;

namespace PassWallet.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public Task<PasswordDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PasswordDto>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(PasswordDto dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PasswordDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PasswordDto dto)
        {
            throw new NotImplementedException();
        }
    }
}