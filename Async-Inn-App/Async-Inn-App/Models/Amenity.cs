using System.Collections.Generic;

namespace Async_Inn_App.Models
{
    public class Amenity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Nav
        public List<RoomAmenity> RoomAmenities { get; set; }
    }
}
