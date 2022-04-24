namespace Async_Inn_App.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public byte PetFriendly { get; set; } 

        //Nav
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
