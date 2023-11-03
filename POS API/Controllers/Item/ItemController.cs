using System.Net;
using CommonLibrary.Model.Item;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using POS_API.Models;

namespace POS_API;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly POSContext _context;
    public ItemController(POSContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetItems()
    {
        if (_context.Items == null)
        {
            return NotFound();
        }

        return await _context.Items.Where(e => e.IsActive).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }

        Item? item = await _context.Items
        .FirstOrDefaultAsync(e => e.ItemId == id);

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateItem(Item item)
    {
        if (_context.Items == null)
        {
            return Problem("Entity Customer does not exist");
        }

        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
        ItemPriceHistory priceHistory = new()
        {
            Price = item.Price,
            Timestamp = DateTime.Now,
            ItemId = item.ItemId
        };
        await _context.ItemPriceHistories.AddAsync(priceHistory);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Item", new { id = item.ItemId }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, Item item)
    {
        if (id != item.ItemId)
        {
            return BadRequest();
        }

        Item? dbItem = await _context.Items.FirstOrDefaultAsync(e => e.ItemId == id);

        if (dbItem == null)
        {
            return NotFound();
        }

        _context.Entry(item).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        if (dbItem.Price != item.Price)
        {
            ItemPriceHistory itemPriceHistory = new()
            {
                ItemId = item.ItemId,
                Price = item.Price,
                Timestamp = DateTime.Now
            };
            await _context.AddAsync(itemPriceHistory);
            await _context.SaveChangesAsync();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        if (_context.Items == null)
        {
            return NotFound();
        }
        Item? item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        item.IsActive = false;

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
