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
    public class Student2Controller : ControllerBase
    {
        private readonly EdDBContext _context;

        public Student2Controller(EdDBContext context)
        {
            _context = context;
        }

        // GET: api/Student2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student2>>> GetStudents2()
        {
            return await _context.Students2.ToListAsync();
        }

        // GET: api/Student2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student2>> GetStudent2(int id)
        {
            var student2 = await _context.Students2.FindAsync(id);

            if (student2 == null)
            {
                return NotFound();
            }

            return student2;
        }

        // PUT: api/Student2/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent2(int id, Student2 student2)
        {
            if (id != student2.Id)
            {
                return BadRequest();
            }

            _context.Entry(student2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student2Exists(id))
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

        // POST: api/Student2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Student2>> PostStudent2(Student2 student2)
        {
            _context.Students2.Add(student2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent2", new { id = student2.Id }, student2);
        }

        // DELETE: api/Student2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student2>> DeleteStudent2(int id)
        {
            var student2 = await _context.Students2.FindAsync(id);
            if (student2 == null)
            {
                return NotFound();
            }

            _context.Students2.Remove(student2);
            await _context.SaveChangesAsync();

            return student2;
        }

        private bool Student2Exists(int id)
        {
            return _context.Students2.Any(e => e.Id == id);
        }
    }
}
