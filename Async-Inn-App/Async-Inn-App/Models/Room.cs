using System.Collections.Generic;

namespace Async_Inn_App.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }

        //Nav
        public List<RoomAmenity> RoomAmenities { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }
        
    }
}
