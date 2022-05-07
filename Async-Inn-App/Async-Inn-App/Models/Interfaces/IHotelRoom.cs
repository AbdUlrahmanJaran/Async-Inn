using Async_Inn_App.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom);
        Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId);
        Task<HotelRoomDTO> GetHotelRoom(int hotelId , int roomNumber);
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);
        Task Delete(int hotelId , int roomId);

        Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hotelRoom);
        Task DeleteRoomFromHotel(int roomId, int hotelId);
    }
}
