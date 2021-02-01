using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DTO.User.Commands;
using PassWallet.Infrastructure.DTO.User.Queries;

namespace PassWallet.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            
            return user is not null
                ? new UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    PasswordHash = user.PasswordHash,
                    Passwords = user.Passwords
                }
                : default;
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.BrowseAsync();

            return users.Select(x => new UserDto()
            {
                Id = x.Id,
                PasswordHash = x.PasswordHash,
                Login = x.Login,
                Passwords = x.Passwords
            }).ToList();
        }

        public Task Register(RegisterUserCommand command)
        {
            throw new NotImplementedException();
        }

        public Task Login(LoginUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}