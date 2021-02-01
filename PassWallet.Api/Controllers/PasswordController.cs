using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.Commands;
using PassWallet.Infrastructure.Services;

namespace PassWallet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PasswordDto>> GetAsync(Guid id)
        {
            var password = await _passwordService.GetAsync(id);
            if (password is null)
            {
                return NotFound();
            }

            return Ok(password);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordDto>>> BrowseAsync()
            => Ok(await _passwordService.BrowseAsync());
        
        [HttpPost]
        public async Task<ActionResult> AddAsync(CreatePasswordCommand command)
        {
            await _passwordService.AddAsync(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(DeletePasswordCommand command)
        {
            await _passwordService.DeleteAsync(command);
            return Ok();
        }
    }
}