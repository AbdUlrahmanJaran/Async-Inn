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

        // GET: api/HotelRooms/5/2
        [HttpGet("{hotelId}/{roomId}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomId)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomId);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        //// PUT: api/HotelRooms/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        //{
        //    if (id != hotelRoom.HotelID)
        //    {
        //        return BadRequest();
        //    }

        //    _hotelRoom.Entry(hotelRoom).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HotelRoomExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/HotelRooms
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        //{
        //    _context.HotelRooms.Add(hotelRoom);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (HotelRoomExists(hotelRoom.HotelID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelID }, hotelRoom);
        //}

        //// DELETE: api/HotelRooms/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteHotelRoom(int id)
        //{
        //    var hotelRoom = await _context.HotelRooms.FindAsync(id);
        //    if (hotelRoom == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.HotelRooms.Remove(hotelRoom);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool HotelRoomExists(int id)
        //{
        //    return _context.HotelRooms.Any(e => e.HotelID == id);
        //}
    }
}
