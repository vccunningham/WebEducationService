using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEducationService.Data;
using WebEducationService.Models;

namespace WebEducationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolledsController : ControllerBase
    {
        private readonly EdDBContext _context;

        public EnrolledsController(EdDBContext context)
        {
            _context = context;
        }

        // GET: api/Enrolleds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrolled>>> GetEnrolled()
        {
            return await _context.Enrolled.ToListAsync();
        }

        // GET: api/Enrolleds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrolled>> GetEnrolled(int id)
        {
            var enrolled = await _context.Enrolled.FindAsync(id);

            if (enrolled == null)
            {
                return NotFound();
            }

            return enrolled;
        }

        // PUT: api/Enrolleds/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrolled(int id, Enrolled enrolled)
        {
            if (id != enrolled.Id)
            {
                return BadRequest();
            }

            _context.Entry(enrolled).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrolledExists(id))
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

        // POST: api/Enrolleds
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Enrolled>> PostEnrolled(Enrolled enrolled)
        {
            _context.Enrolled.Add(enrolled);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnrolled", new { id = enrolled.Id }, enrolled);
        }

        // DELETE: api/Enrolleds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Enrolled>> DeleteEnrolled(int id)
        {
            var enrolled = await _context.Enrolled.FindAsync(id);
            if (enrolled == null)
            {
                return NotFound();
            }

            _context.Enrolled.Remove(enrolled);
            await _context.SaveChangesAsync();

            return enrolled;
        }

        private bool EnrolledExists(int id)
        {
            return _context.Enrolled.Any(e => e.Id == id);
        }
    }
}
