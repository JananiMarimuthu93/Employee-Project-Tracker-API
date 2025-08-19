using Employee_Project_Tracker_API.IAuthentication;
using Employee_Project_Tracker_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Project_Tracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly EmployeeProjectTrackerContext _con;

        private readonly ITokenGenerate _tokenService;
        public TokenController(EmployeeProjectTrackerContext con, ITokenGenerate tokenService)
        {
            _con = con;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(User userData)
        {
            if (userData != null && !string.IsNullOrEmpty(userData.Email) && !string.IsNullOrEmpty(userData.Password) && !string.IsNullOrEmpty(userData.Role))
            {
                var user = await GetUser(userData.Email, userData.Password,userData.Role);
                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user);
                    return Ok(new { token });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Invalid request data");
            }

        }
        private async Task<User> GetUser(string email, string password,string role)
        {
            return await _con.User.FirstOrDefaultAsync(u => u.Email == email &&
            u.Password == password && u.Role==role) ?? new Models.User();
        }
    }
}
