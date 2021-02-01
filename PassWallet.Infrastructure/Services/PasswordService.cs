using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PassWallet.Core.Entities;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.Commands;
using PassWallet.Infrastructure.Exceptions;
using PassWallet.Infrastructure.Extensions;

namespace PassWallet.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly PasswordEncoder _passwordEncoder;

        public PasswordService(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
            _passwordEncoder = new PasswordEncoder();
        }
        
        public async Task<PasswordDto> GetAsync(Guid id)
        {
            var password = await _passwordRepository.GetAsync(id);

            return password is not null
                ? new PasswordDto
                {
                    Id = password.Id,
                    PasswordHash = password.PasswordHash,
                    Website = password.Website,
                    Login = password.Login,
                    Description = password.Description,
                    Owner = password.Owner
                }
                : default;
        }

        public async Task<IEnumerable<PasswordDto>> BrowseAsync()
        {
            var passwords = await _passwordRepository.BrowseAsync();

            return passwords.Select(x => new PasswordDto()
            {
                Id = x.Id,
                PasswordHash = x.PasswordHash,
                Website = x.Website,
                Login = x.Login,
                Description = x.Description,
                Owner = x.Owner
            }).ToList();
        }

        public async Task AddAsync(CreatePasswordCommand command)
        {
            var password = new Password
            {
                PasswordHash = _passwordEncoder.Encrypt(command.PasswordHash, command.VaultKey),
                Website = command.Website,
                Login = command.Login,
                Description = command.Description,
                Owner = command.Owner
            };

            await _passwordRepository.AddAsync(password);
        }

        public async Task UpdateAsync(UpdatePasswordCommand command)
        {
            var password = await _passwordRepository.GetAsync(command.Id);
            if (password is null)
                throw new PasswordNotFoundException(command.Id);
            
            password.PasswordHash = _passwordEncoder.Encrypt(command.PasswordHash, command.VaultKey);
            await _passwordRepository.UpdateAsync(password);
        }

        public async Task DeleteAsync(DeletePasswordCommand command)
        {
            var password = await _passwordRepository.GetAsync(command.Id);
            if (password is null)
                throw new PasswordNotFoundException(command.Id);

            await _passwordRepository.DeleteAsync(password);
        }
    }
}