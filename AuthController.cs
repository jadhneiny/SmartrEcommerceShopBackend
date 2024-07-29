using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopManagementBackend.Models;
using ShopManagementBackend.Repositories;
using ShopManagementBackend.Services;
using System.Threading.Tasks;

namespace ShopManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository<TBL_ADMINS> _adminRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserRepository<TBL_ADMINS> adminRepository, ITokenService tokenService, ILogger<AuthController> logger)
        {
            _adminRepository = adminRepository;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            _logger.LogInformation("Login attempt for user: {Username}", model.Username);

            var admin = await _adminRepository.GetByUsernameAsync(model.Username);

            if (admin == null)
            {
                _logger.LogWarning("User not found: {Username}", model.Username);
                return Unauthorized("Invalid credentials");
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, admin.PASSWORD))
            {
                _logger.LogWarning("Invalid password for user: {Username}", model.Username);
                return Unauthorized("Invalid credentials");
            }

            var token = _tokenService.CreateToken(admin);
            _logger.LogInformation("Token created for user: {Username}", model.Username);

            return Ok(new { token });
        }
    }
}
