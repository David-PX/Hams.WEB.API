using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hams.WEB.API.Models;
using Hams.WEB.API.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Hams.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GuestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/Guests
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        //{
        //  if (_context.Guests == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Guests.ToListAsync();
        //}

        //// GET: api/Guests/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Guest>> GetGuest(int? id)
        //{
        //  if (_context.Guests == null)
        //  {
        //      return NotFound();
        //  }
        //    var guest = await _context.Guests.FindAsync(id);

        //    if (guest == null)
        //    {
        //        return NotFound();
        //    }

        //    return guest;
        //}

        // PUT: api/Guests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]       
        public async Task<IActionResult> PutGuest(int? id, GuestCreationDTO dto)
        {
            if (id != dto.ID)
            {
                 return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "Error ocurred" });
            }

            var existingGuest = _context.Guests.FirstOrDefault(g => g.ID == id);

            if (existingGuest == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = "No found" });
            }

            existingGuest.Names = dto.Names;
            existingGuest.LastNames = dto.LastNames;
            existingGuest.PhoneNumber = dto.PhoneNumber;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = "Guest Updated Successfully" });
        }

        //// POST: api/Guests
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Guest>> PostGuest(Guest guest)
        //{
        //  if (_context.Guests == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.Guests'  is null.");
        //  }
        //    _context.Guests.Add(guest);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGuest", new { id = guest.ID }, guest);
        //}

        //// DELETE: api/Guests/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGuest(int? id)
        //{
        //    if (_context.Guests == null)
        //    {
        //        return NotFound();
        //    }
        //    var guest = await _context.Guests.FindAsync(id);
        //    if (guest == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Guests.Remove(guest);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool GuestExists(int? id)
        {
            return (_context.Guests?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
