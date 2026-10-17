using Microsoft.Asp.NetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Modells;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategotryController : ControllerBase
    {
        private reaadonly
        RaceDayContext _ context;

        public
        CategoryController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async
        Task<IActionResult> GetCategory()
        {
            var category = await
            _context.Category.ToListAsync();

            return Ok(category);
        }

        [HttpGet({"id"})]
        public async
        Task<IActionResult> GetCategory(int id)
        {
            var category = await
            _context.Category
            .FirstOrDefaultAsync(c => c.CategoryID == id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public async
        Task<IActionResult>
        CreateCategory(Category category)
        {
            _context.Category.Add(category);

            await
            _context.SaveChangesAsync();
            return Ok(category);
        }
        [HttpPut({"id"})]
        public async
        Task<IActionResult> UpdatedCategory(
            int id, Category updatedCategory
        )
        {
            var category = await
            _context.Categories
            .FirstOrDefaultAsync(c =>
            c.CategoryID == id);

            if(category == null)
            {
                return NotFound();
            }

            category.CategoryName = updatedCtaegory.CategoryName;
            category.CategoryDistance = updatedCategory.CategoryDistance;
            category.EntryFee = updatedCategory.EntryFee;
            category.EventID = updatedCategory.EventID;

            await
            _context.SaveChabgesAsync();
            return Ok(category);
        }

        [HttpDelete("id")]
        public async
        Task<IActionResult>
        DeleteCategory(int id)
        {
            var category = await _contextCategory
            .FirstOrDefaultAsync(c => c,CategoryID ==id);

            if(category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await
            _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Category deleted successfully"
            });
        }
    }
}