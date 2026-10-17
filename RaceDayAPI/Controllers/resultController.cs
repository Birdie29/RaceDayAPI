using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameowrkCore;
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class resultController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public resultController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async
        Task<IActionResult> GetResult()
        {
            var results = await
            _context.result.ToListAsync();

            return Ok(results);
        }

        [HttpPost]
        public async
        Task<IActionResult>
        CreateResult(Results result)
        {
            _Context.Results.Add(result);

            await
            _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetResultById),
                new {id = result.result.ID},
                result
            );
        }

        [HttpGet("{id}")]
        public async 
        Task<IActionResult>
        GetResultById(int id)
        {
            var result = await
            _context.Results

            .FirstOrDefaultAsync(r => r.resultID = id);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Results not found."
                });
            }

            result.position = updatedResult.position;
            result.participantStatus = updatedResult.participantStatus;
            result.finishTime = updatedResult.finishTime;
            result.registrationID = updatedResult.registrationID;

            await
            _content.SaveChangesAsync();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async
        Task<IActionResult> DeleteResult(int id)
        {
            var result = await
            _context.Results

            .FirstOrDefaultAsync(r => r.resultID == id);

            if(result == null)
            {
                return NotFound(new
                {
                    message = "Result not found."
                });
            }

            _context.Results.Remove(result);
            await
            _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Result deleted successfully"
            });
        }
        
    }
}