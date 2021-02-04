using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.Commands;
using PassWallet.Infrastructure.Services;
using PassWallet.Infrastructure.Exceptions;

namespace PassWallet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserService _userService;

        public PasswordController(IPasswordService passwordService, IUserService userService)
        {
            _passwordService = passwordService;
            _userService = userService;
        }
        
        [Authorize]
        [HttpGet("single")]
        public async Task<ActionResult<PasswordDto>> GetAsync(Guid id)
        {
            var password = await _passwordService.GetAsync(id);
            
            if (password is null)
            {
                return NotFound();
            }

            return Ok(password);
        }
        
        [HttpGet("allAdmin")]
        public async Task<ActionResult<IEnumerable<PasswordDto>>> BrowseAsync()
            => Ok(await _passwordService.BrowseAsync());

        [Authorize]
        [HttpPost("all")]
        public async Task<ActionResult<IEnumerable<PasswordDto>>> BrowseAsyncById()
        {
            var userId = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
            if (String.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(
                    $"User with ID: {userId} does not exist.",userId);
            
            return Ok(await _passwordService.BrowseAsync(
                new GetPasswordsByUserCommand(Guid.Parse(userId))));
        }

        [Authorize]
        [HttpPost("decrypted")]
        public async Task<ActionResult<PasswordDto>> GetDecryptedPassword(GetDecryptedPassword command)
        {
            var userId = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
            if (String.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(
                    $"User with ID: {userId} does not exist.",userId);
            var password = await _passwordService
                .GetDecryptedPassword(command, Guid.Parse(userId));
            
            if (password is null)
                return NotFound();
            return Ok(password);
        }

        
        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult> AddAsync(CreatePasswordCommand command)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (String.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(
                    $"User with ID: {userId} does not exist.",userId);

            await _passwordService.AddAsync(command, Guid.Parse(userId));
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteAsync(DeletePasswordCommand command)
        {
            if (command.PasswordId == null || command.PasswordId == Guid.Empty)
                throw new ArgumentNullException(
                    $"Password with ID: {command.PasswordId} does not exist.", command.PasswordId.ToString());
            
            await _passwordService.DeleteAsync(command);
            return Ok();
        }
    }
}