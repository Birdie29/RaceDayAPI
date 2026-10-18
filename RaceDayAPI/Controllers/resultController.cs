using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public ResultController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var results = await _context.Results.ToListAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResultById(int id)
        {
            var result = await _context.Results.FindAsync(id);

            if (result == null)
            {
                return NotFound(new { message = "Result not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResult(Result newResult)
        {
            _context.Results.Add(newResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetResultById),
                new { id = newResult.resultID },
                newResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResult(int id, Result updatedResult)
        {
            if (id != updatedResult.resultID)
            {
                return BadRequest("Result ID does not match.");
            }

            var result = await _context.Results.FindAsync(id);
            if (result == null)
            {
                return NotFound(new { message = "Result not found." });
            }

            result.position = updatedResult.position;
            result.participantStatus = updatedResult.participantStatus;
            result.finishTime = updatedResult.finishTime;
            result.registrationID = updatedResult.registrationID;

            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            var result = await _context.Results.FindAsync(id);

            if (result == null)
            {
                return NotFound(new { message = "Result not found." });
            }

            _context.Results.Remove(result);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}