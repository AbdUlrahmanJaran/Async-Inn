using Async_Inn_App.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces.Services
{
    public class IdentityUserRepository : IUserService
    {
        private UserManager<ApplicationUser> userManager;

        public IdentityUserRepository(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }

        public async Task<UserDTO> Authenticate(LoginDataDTO data, ModelStateDictionary modelState)
        {
            var user = await userManager.FindByNameAsync(data.UserName);
            if(await userManager.CheckPasswordAsync(user, data.Password))
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }
            else
            {
                throw new Exception("Invalid Password");
            }
            return null;
        }

        public async Task<ApplicationUser> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            // throw new NotImplementedException();
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, data.Password);
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }

    }
}
