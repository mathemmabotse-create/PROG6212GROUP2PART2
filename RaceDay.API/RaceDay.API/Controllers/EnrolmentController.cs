using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnrolmentsController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Enrolments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrolment>>>
            GetEnrolments()
        {
            return await _context.Enrolments.ToListAsync();
        }

        // GET: api/Enrolments/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrolment>>
            GetEnrolment(int id)
        {
            var enrolment =
                await _context.Enrolments.FindAsync(id);

            if (enrolment == null)
                return NotFound();

            return enrolment;
        }

        // POST: api/Enrolments
        [HttpPost]
        public async Task<ActionResult<Enrolment>>
            CreateEnrolment(Enrolment enrolment)
        {
            bool alreadyEnrolled =
                await _context.Enrolments.AnyAsync(e =>
                    e.UserID == enrolment.UserID &&
                    e.EventCategoryID == enrolment.EventCategoryID);

            if (alreadyEnrolled)
            {
                return Conflict(
                    "This participant is already enrolled in this category.");
            }

            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEnrolment),
                new { id = enrolment.EnrolmentID },
                enrolment);
        }

        // PUT: api/Enrolments/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrolment(
            int id, Enrolment enrolment)
        {
            if (id != enrolment.EnrolmentID)
                return BadRequest();

            bool exists = await _context.Enrolments
                .AnyAsync(e => e.EnrolmentID == id);

            if (!exists)
                return NotFound();

            _context.Entry(enrolment).State =
                EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Enrolments/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrolment(int id)
        {
            var enrolment =
                await _context.Enrolments.FindAsync(id);

            if (enrolment == null)
                return NotFound();

            _context.Enrolments.Remove(enrolment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}