using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn_App.Data;
using Async_Inn_App.Models;
using Async_Inn_App.Models.Interfaces;

namespace Async_Inn_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet("{hotelId}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _hotelRoom.GetHotelRooms(hotelId);
            return Ok(hotelRooms);
        }

        // GET: api/HotelRooms/1/Rooms/1
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomNumber);
            return Ok(hotelRoom);
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(HotelRoom hotelRoom)
        {
            var modifiedHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(modifiedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int hotelId, HotelRoom hotelRoom)
        {
            await _hotelRoom.AddRoomToHotel(hotelId, hotelRoom);
            return NoContent();
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomId)
        {
            await _hotelRoom.DeleteRoomFromHotel(hotelId, roomId);
            return NoContent();
        }

        //private bool HotelRoomExists(int id)
        //{
        //    return _context.HotelRooms.Any(e => e.HotelID == id);
        //}
    }
}
