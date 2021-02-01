using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.Commands;
using PassWallet.Infrastructure.DTO.User.Commands;
using PassWallet.Infrastructure.DTO.User.Queries;

namespace PassWallet.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(Guid id);
        Task<IEnumerable<UserDto>> BrowseAsync();
        Task RegisterAsync(RegisterUserCommand command);
        Task<TokenDto> LoginAsync(LoginUserCommand command);
    }
}