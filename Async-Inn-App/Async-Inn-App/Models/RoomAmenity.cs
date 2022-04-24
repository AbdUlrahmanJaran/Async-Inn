namespace Async_Inn_App.Models
{
    public class RoomAmenity
    {
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        //Nav
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
        
    }
}
