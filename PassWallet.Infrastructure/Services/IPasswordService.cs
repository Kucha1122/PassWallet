using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.Commands;

namespace PassWallet.Infrastructure.Services
{
    public interface IPasswordService
    {
        Task<PasswordDto> GetAsync(Guid id);
        Task<PasswordDto> GetDecryptedPassword(GetDecryptedPassword command, Guid userId);
        Task<IEnumerable<PasswordDto>> BrowseAsync();
        Task<IEnumerable<PasswordDto>> BrowseAsync(GetPasswordsByUserCommand command);
        Task AddAsync(CreatePasswordCommand command, Guid userId);
        Task UpdateAsync(UpdatePasswordCommand command, Guid userId);
        Task DeleteAsync(DeletePasswordCommand command);
    }
}