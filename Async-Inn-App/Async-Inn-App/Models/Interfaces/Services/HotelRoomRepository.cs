using Async_Inn_App.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            var hotelrooms = await _context.HotelRooms
                .Where(h => h.HotelID == hotelId)
                .Include(h => h.Hotel)
                .Include(r => r.Room)
                .ThenInclude(a => a.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .ToListAsync();
            return hotelrooms;
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelID == hotelId && hr.RoomNumber == roomNumber)
                .Include(x => x.Room)
                .ThenInclude(h => h.HotelRooms)
                .ThenInclude(x => x.Hotel)
                .Include(x => x.Room)
                .ThenInclude(a => a.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .FirstOrDefaultAsync(x => x.HotelID == hotelId && x.RoomNumber == roomNumber);

            return hotelRoom;
        }

        public async Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task DeleteRoomFromHotel(int roomId, int hotelId)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(h => h.HotelID == hotelId && h.RoomID == roomId)
                .FirstAsync();

            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
