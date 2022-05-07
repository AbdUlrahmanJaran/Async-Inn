using Async_Inn_App.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(RoomDTO room);
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> GetRoom(int id);
        Task<Room> UpdateRoom(int id, RoomDTO room);
        Task Delete(int id);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
