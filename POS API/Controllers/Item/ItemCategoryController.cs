using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;

namespace POS_API;

[Route("api/[controller]")]
[ApiController]
public class ItemCategoryController : ControllerBase
{
    private readonly POSContext _context;
    public ItemCategoryController(POSContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommonLibrary.Model.Item.ItemCategory>>> GetItemCategories()
    {
        if (_context.ItemCategories == null)
        {
            return NotFound();
        }

        return await _context.ItemCategories.Where(e => e.IsActive).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommonLibrary.Model.Item.ItemCategory>> GetItemCategory(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }

        CommonLibrary.Model.Item.ItemCategory? itemCategory = await _context.ItemCategories
        .FirstOrDefaultAsync(e => e.ItemCategoryId == id);

        if (itemCategory == null)
        {
            return NotFound();
        }

        return itemCategory;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateItem(CommonLibrary.Model.Item.ItemCategory itemCategory)
    {
        if (_context.ItemCategories == null)
        {
            return Problem("Entity Customer does not exist");
        }

        await _context.ItemCategories.AddAsync(itemCategory);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Customer", new { id = itemCategory.ItemCategoryId }, itemCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItemCategory(int id, CommonLibrary.Model.Item.ItemCategory item)
    {
        if (id != item.ItemCategoryId)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemCategoryExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItemCategory(int id)
    {
        if (_context.ItemCategories == null)
        {
            return NotFound();
        }
        CommonLibrary.Model.Item.ItemCategory? item = await _context.ItemCategories.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        item.IsActive = false;

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }


    private bool ItemCategoryExists(int id)
    {
        return (_context.ItemCategories?.Any(e => e.ItemCategoryId == id)).GetValueOrDefault();
    }
}
