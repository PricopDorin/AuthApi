using AuthentificationApi.Context;
using AuthentificationApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthentificationApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public AuthentificationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            if (user == null)
                return BadRequest();

            var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            if (result == null)
                return NotFound(new { Message = "User Not Found!" });

            return Ok(new { Message = "Login Succes!" });
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(User user) 
        {
            if (user == null)
                return BadRequest();

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok(new { Message = "User Registred!" });
        }
    }
}
