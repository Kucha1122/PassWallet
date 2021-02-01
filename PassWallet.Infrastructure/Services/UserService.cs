using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Generators;
using PassWallet.Core.Entities;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.User.Commands;
using PassWallet.Infrastructure.DTO.User.Queries;
using PassWallet.Infrastructure.Exceptions;
using PassWallet.Infrastructure.Extensions;
using PassWallet.Infrastructure.Handlers;

namespace PassWallet.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordEncoder _passwordEncoder;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _passwordEncoder = new PasswordEncoder();
            _jwtHandler = jwtHandler;
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
                    Passwords = user.Passwords,
                    Salt = user.Salt,
                    Role = user.Role
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
                Passwords = x.Passwords,
                Salt = x.Salt,
                Role = x.Role
            }).ToList();
        }

        public async Task Register(RegisterUserCommand command)
        {
            var user = await _userRepository.GetAsync(command.Login);
            if (user != null)
                throw new UserAlreadyExistException(command.Login);

            var salt = _passwordEncoder.GenerateRandomSalt();

            user = new User
            {
                Login = command.Login,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.Password + salt),
                Passwords = new List<Password>()
            };
            user.SetRole("user");
            
            await _userRepository.AddAsync(user);
        }

        public async Task<TokenDto> Login(LoginUserCommand command)
        {
            var user = await _userRepository.GetAsync(command.Login);
            if (user is null)
                throw new UserNotFoundException(command.Login);

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(command.Password + user.Salt, user.PasswordHash);
            if (isValidPassword)
            {
                var jwt = _jwtHandler.CreateToken(user.Id, user.Role);

                return new TokenDto
                {
                    Id = user.Id,
                    Token = jwt.Token,
                    Expires = jwt.Expires,
                    Role = user.Role,
                    Login = user.Login
                };
            }

            throw new InvalidCredentialsException();
        }
    }
}