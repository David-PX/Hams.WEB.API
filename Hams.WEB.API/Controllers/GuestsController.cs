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

        private bool GuestExists(int? id)
        {
            return (_context.Guests?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
