using Async_Inn_App.Models;
using Async_Inn_App.Models.DTO;
using Async_Inn_App.Models.Interfaces.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestAsync_Inn
{
    public class UnitTest1 : Mock
    {
        [Fact]
        public async Task CanAddAndDeleteRoomToHotel()
        {
            // Arrange
            var hotel = await CreateAndSaveTestHotel();
            var room = await CreateAndSaveTestRoom();

            var repository = new HotelRoomRepository(_db);

            // Act
            await repository.AddRoomToHotel(hotel.ID, new HotelRoom
            {
                HotelID = hotel.ID,
                RoomID = room.ID,
                Rate = 5,
                RoomNumber = 110,
            });

            // Assert
            var actualHotelRoom = await repository.GetHotelRoom(hotel.ID, 110);
            Assert.Equal(room.ID, actualHotelRoom.RoomID);

            // Act
            await repository.DeleteRoomFromHotel(room.ID ,hotel.ID);

            // Assert
            var deleted = await repository.GetHotelRoom(hotel.ID, room.ID);
            Assert.Null(deleted);
        }

        [Fact]
        public async Task CanAddAndDeleteAmenityToRoom()
        {
            // Arrange
            var amenity = await CreateAndSaveTestAmenity();
            var room = await CreateAndSaveTestRoom();

            var repository = new RoomRepository(_db);

            // Act
            await repository.AddAmenityToRoom(room.ID, amenity.ID);

            // Assert
            var actualRoom = await repository.GetRoom(room.ID);
            Assert.Contains(actualRoom.Amenities, r => r.ID == amenity.ID);

            // Act
            await repository.RemoveAmentityFromRoom(room.ID, amenity.ID);

            // Assert
            actualRoom = await repository.GetRoom(room.ID);
            Assert.DoesNotContain(actualRoom.Amenities, r => r.ID == amenity.ID);
        }
    }
}
