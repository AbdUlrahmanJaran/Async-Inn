using Async_Inn_App.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> Create(AmenityDTO amenity);
        Task<List<AmenityDTO>> GetAmenities();
        Task<AmenityDTO> GetAmenity(int id);
        Task<Amenity> UpdateAmenity(int id, AmenityDTO amenity);
        Task Delete(int id);
    }
}
