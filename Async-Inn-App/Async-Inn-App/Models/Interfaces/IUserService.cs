using Async_Inn_App.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces
{
    public interface IUserService
    {
        public Task<ApplicationUser> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(LoginDataDTO data, ModelStateDictionary modelState);
    }
}
