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
                .Include(x => x.Room)
                .ThenInclude(x => x.HotelRooms)
                .ToListAsync();
            return hotelrooms;
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomId)
        {
            //HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomId);
            //var hotel = await _context.HotelRooms
            //    .Where(x => x.HotelID == hotelId)
            //    .Include(x => x.Hotel)
            //    .FirstOrDefaultAsync(x => x.HotelID == hotelId);
            //var room = await _context.HotelRooms
            //    .Where(x => x.RoomID == roomId)
            //    .Include(x => x.Room)
            //    .FirstOrDefaultAsync(x => x.RoomID == roomId);
            
            return await _context.HotelRooms
                .Include(x => x.Hotel)
                .ThenInclude(x => x.HotelRooms)
                .FirstOrDefaultAsync(x => x.HotelID == hotelId && x.RoomID == roomId);
        }

        public async Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelId, int roomId)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomId);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
