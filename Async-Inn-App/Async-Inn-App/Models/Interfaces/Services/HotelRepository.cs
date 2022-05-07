using Async_Inn_App.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces.Services
{
    public class HotelRepository : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels
                .Include(x => x.HotelRooms)
                .ThenInclude(x => x.Room)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .ToListAsync(); 
            return hotels;
        }
        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            var hotelRooms = await _context.HotelRooms
                .Where(x => x.HotelID == id)
                .Include(x => x.Room)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .ToListAsync();
            hotel.HotelRooms = hotelRooms;
            return hotel;
        }
        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
