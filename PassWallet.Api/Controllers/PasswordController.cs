using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using PassWallet.Core.Entities;
using PassWallet.Core.Repositories;
using PassWallet.Infrastructure.DAL.Repositories;
using PassWallet.Infrastructure.DTO;

namespace PassWallet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private IPasswordRepository _passwordRepository; //FOR TEST

        public PasswordController(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Post(PasswordDto dto)
        {
            var pass = new Password
            {
                Login = dto.Login,
                PasswordHash = dto.PasswordHash,
                Description = dto.Description,
                Owner = dto.Owner,
                Website = dto.Website
            };
            await _passwordRepository.AddAsync(pass);
            return Ok(pass);
        }
    }
}