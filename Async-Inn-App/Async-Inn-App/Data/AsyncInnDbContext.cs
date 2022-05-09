using Microsoft.EntityFrameworkCore;
using Async_Inn_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Async_Inn_App.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, and Identity needs it
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { ID = 1, City = "Amman", Country = "Jordan", Name = "AsyncInn Amman", Phone = "+962775777777", State = "", StreetAddress = "St1-2" },
                new Hotel { ID = 2, City = "Irbid", Country = "Jordan", Name = "AsyncInn Irbid", Phone = "+962775777778", State = "", StreetAddress = "St3-4" },
                new Hotel { ID = 3, City = "Jerash", Country = "Jordan", Name = "AsyncInn Jerash", Phone = "+962775777779", State = "", StreetAddress = "St5-6" }
                );
           
            modelBuilder.Entity<Room>().HasData(
                new Room { ID = 1, Name = "FirstStudio" , Layout = 0 },
                new Room { ID = 2, Name = "FirstOneBedroom", Layout = 1 },
                new Room { ID = 3, Name = "FirstTwoBedroom", Layout = 2 }
                );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { ID = 2, Name = "Air Conditioner" },
                new Amenity { ID = 1, Name = "Coffee Machine" },
                new Amenity { ID = 3, Name = "Sea View" }
                );

            modelBuilder.Entity<RoomAmenity>().HasKey(
                roomAmenities => new {roomAmenities.RoomID , roomAmenities.AmenityID});

            modelBuilder.Entity<HotelRoom>().HasKey(
                hotelRooms => new {hotelRooms.HotelID , hotelRooms.RoomID });
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
    }
}
