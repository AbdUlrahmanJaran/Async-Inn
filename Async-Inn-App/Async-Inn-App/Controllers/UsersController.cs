using Async_Inn_App.Models;
using Async_Inn_App.Models.DTO;
using Async_Inn_App.Models.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            if (!string.IsNullOrEmpty(data.UserName) && string.IsNullOrEmpty(data.Password))
            {

            }
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            if (data.UserName == "admin")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,data.UserName),
                    new Claim(ClaimTypes.Role,"Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }

            if (data.UserName == "employee")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,data.UserName),
                    new Claim(ClaimTypes.Role,"Employee")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }

            if (data.UserName == "coustomer")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,data.UserName),
                    new Claim(ClaimTypes.Role,"Coustomer")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }

            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            return await _user.Authenticate(data, ModelState);
        }
    


        [HttpPost("Register")]
        public async Task<ApplicationUser> Register(RegisterUserDTO data)
        {
            return await _user.Register(data, ModelState);
        }
    }
}
