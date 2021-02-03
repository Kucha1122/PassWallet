using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PassWallet.Core.Entities;
using PassWallet.Core.Interfaces;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.Commands;
using PassWallet.Infrastructure.DTO.User.Queries;
using PassWallet.Infrastructure.Exceptions;
using PassWallet.Infrastructure.Extensions;

namespace PassWallet.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordEncoder _passwordEncoder;

        public PasswordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _passwordEncoder = new PasswordEncoder();
        }
        
        public async Task<PasswordDto> GetAsync(Guid id)
        {
            var password = await _unitOfWork.Passwords.GetAsync(id);

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
            var passwords = await _unitOfWork.Passwords.GetAllAsync();

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

        public async Task<IEnumerable<PasswordDto>> BrowseAsync(Guid id)
        {
            var passwords = await _unitOfWork.Passwords.FindAsync(x => x.User.Id == id);

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

        public async Task AddAsync(CreatePasswordCommand command, UserDto dto)
        {
            var password = new Password
            {
                PasswordHash = _passwordEncoder.Encrypt(command.PasswordHash, command.VaultKey),
                Website = command.Website,
                Login = command.Login,
                Description = command.Description,
                Owner = command.Owner,
                User = new User
                {
                    Login = dto.Login,
                    PasswordHash = dto.PasswordHash,
                    Salt = dto.Salt,
                    Role = dto.Role,
                    Passwords = dto.Passwords
                }
                
            };
            
            await _unitOfWork.Passwords.AddAsync(password);
            _unitOfWork.Complete();
        }

        public async Task UpdateAsync(UpdatePasswordCommand command)
        {
            var password = await _unitOfWork.Passwords.GetAsync(command.Id);
            if (password is null)
                throw new PasswordNotFoundException(command.Id);
            
            password.PasswordHash = _passwordEncoder.Encrypt(command.PasswordHash, command.VaultKey);
            await _unitOfWork.Passwords.UpdateAsync(password);
            _unitOfWork.Complete();
        }

        public async Task DeleteAsync(DeletePasswordCommand command)
        {
            var password = await _unitOfWork.Passwords.GetAsync(command.Id);
            if (password is null)
                throw new PasswordNotFoundException(command.Id);
            
            await _unitOfWork.Passwords.RemoveAsync(password);
            _unitOfWork.Complete();
        }
    }
}