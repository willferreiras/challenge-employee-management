using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public UserProfileController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            var user = await _context.Users
                .Where(u => u.Username == username)
                .Select(u => new
                {
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    u.Username,
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            return Ok(user);
        }
    }
}
