using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kochbuch_Backend.Data;
using Kochbuch_Backend.Models;

namespace Kochbuch_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciepesController : ControllerBase
    {
        private readonly KochbuchDbContext _context;

        public ReciepesController(KochbuchDbContext context)
        {
            _context = context;
        }

        // GET: api/Reciepes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reciepe>>> GetReciepes()
        {
            return await _context.Reciepes.ToListAsync();
        }

        // GET: api/Reciepes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reciepe>> GetReciepe(int id)
        {
            var reciepe = await _context.Reciepes.FindAsync(id);

            if (reciepe == null)
            {
                return NotFound();
            }

            return reciepe;
        }

        // PUT: api/Reciepes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReciepe(int id, Reciepe reciepe)
        {
            if (id != reciepe.Id)
            {
                return BadRequest();
            }

            _context.Entry(reciepe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciepeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reciepes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reciepe>> PostReciepe(Reciepe reciepe)
        {
            _context.Reciepes.Add(reciepe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReciepe", new { id = reciepe.Id }, reciepe);
        }

        // DELETE: api/Reciepes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReciepe(int id)
        {
            var reciepe = await _context.Reciepes.FindAsync(id);
            if (reciepe == null)
            {
                return NotFound();
            }

            _context.Reciepes.Remove(reciepe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReciepeExists(int id)
        {
            return _context.Reciepes.Any(e => e.Id == id);
        }
    }
}
