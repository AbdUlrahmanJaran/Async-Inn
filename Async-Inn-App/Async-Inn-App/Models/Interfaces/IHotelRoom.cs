using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom);
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        Task<HotelRoom> GetHotelRoom(int hotelId , int roomId);
        Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom);
        Task Delete(int hotelId , int roomId);
    }
}
