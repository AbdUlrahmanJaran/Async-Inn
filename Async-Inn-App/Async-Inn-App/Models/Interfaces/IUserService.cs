using Async_Inn_App.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(LoginDataDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> GetUser(ClaimsPrincipal principal);
    }
}
