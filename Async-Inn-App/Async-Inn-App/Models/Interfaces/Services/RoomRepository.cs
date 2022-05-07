using Async_Inn_App.Data;
using Async_Inn_App.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(RoomDTO room)
        {
            Room newRoom = new Room
            {
                ID = room.ID,
                Name = room.Name,
                Layout = room.Layout
            };
            _context.Entry(newRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newRoom;
        }
        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.Rooms
                .Select(r => new RoomDTO
                {
                    ID = r.ID,
                    Name = r.Name,
                    Layout = r.Layout,
                    Amenities = r.RoomAmenities
                        .Select(a => new AmenityDTO
                        {
                            ID = a.AmenityID,
                            Name = a.Room.Name
                        }).ToList()
                }).ToListAsync();
        }
        public async Task<RoomDTO> GetRoom(int id)
        {
            RoomDTO room = await _context.Rooms
                .Where(r => r.ID == id)
                 .Select(r => new RoomDTO
                 {
                     ID = r.ID,
                     Name = r.Name,
                     Layout = r.Layout,
                     Amenities = r.RoomAmenities
                         .Select(a => new AmenityDTO
                         {
                             ID = a.AmenityID,
                             Name = a.Room.Name
                         }).ToList()
                 }).FirstOrDefaultAsync();
            return room;
        }
        public async Task<Room> UpdateRoom(int id, RoomDTO room)
        {
            Room modifiededRoom = new Room
            {
                ID = room.ID,
                Name = room.Name,
                Layout = room.Layout
            };
            _context.Entry(modifiededRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return modifiededRoom;
        }
        public async Task Delete(int id)
        {
            RoomDTO room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity
            {
                RoomID = roomId,
                AmenityID = amenityId
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = await _context.RoomAmenities.FindAsync(roomId,amenityId);
            _context.Entry(roomAmenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
