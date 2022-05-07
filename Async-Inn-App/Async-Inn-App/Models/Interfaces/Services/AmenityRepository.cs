using Async_Inn_App.Data;
using Async_Inn_App.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_App.Models.Interfaces.Services
{
    public class AmenityRepository : IAmenity
    {
        private AsyncInnDbContext _context;

        public AmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Amenity> Create(AmenityDTO amenity)
        {
            Amenity newAmenity = new Amenity
            {
                ID = amenity.ID,
                Name = amenity.Name,
            };
            _context.Entry(newAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newAmenity;
        }
        public async Task<List<AmenityDTO>> GetAmenities()
        {
            //var amenities = await _context.Amenities.ToListAsync();
            //return amenities;

            return await _context.Amenities
                .Select(a => new AmenityDTO
                {
                    ID = a.ID,
                    Name = a.Name,
                })
                .ToListAsync();
        }
        public async Task<AmenityDTO> GetAmenity(int id)
        {
            var amenity = await _context.Amenities
                .Where(x => x.ID == id)
                .Select(a => new AmenityDTO
                {
                    ID = a.ID,
                    Name = a.Name
                }).FirstAsync();
            return amenity;
        }
        public async Task<Amenity> UpdateAmenity(int id, AmenityDTO amenity)
        {
            Amenity modifiededAmenity = new Amenity
            {
                ID = amenity.ID,
                Name = amenity.Name,
            };
            _context.Entry(modifiededAmenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return modifiededAmenity;
        }
        public async Task Delete(int id)
        {
            AmenityDTO amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
