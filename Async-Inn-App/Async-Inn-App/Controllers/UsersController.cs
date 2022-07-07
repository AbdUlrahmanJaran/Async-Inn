using Async_Inn_App.Models;
using Async_Inn_App.Models.DTO;
using Async_Inn_App.Models.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Async_Inn_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;

        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("Login")]
        public async Task<UserDTO> Login(LoginDataDTO data)
        {
            var user = await _user.Authenticate(data, ModelState);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        [HttpPost("Register")]
        public async Task<UserDTO> Register(RegisterUserDTO data)
        {
            return await _user.Register(data, ModelState);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserDTO>> Me()
        {
            return await _user.GetUser(this.User);
        }
    }
}
