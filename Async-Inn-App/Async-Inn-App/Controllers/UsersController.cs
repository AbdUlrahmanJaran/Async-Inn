using Async_Inn_App.Models;
using Async_Inn_App.Models.DTO;
using Async_Inn_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            return await _user.Authenticate(data, ModelState);
        }


        [HttpPost("Register")]
        public async Task<ApplicationUser> Register(RegisterUserDTO data)
        {
            return await _user.Register(data, ModelState);
        }
    }
}
