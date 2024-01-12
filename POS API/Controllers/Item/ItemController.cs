using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;
using CommonLibrary.APIRoutes.Item;

namespace POS_API.Controllers.Item;

[Route(ItemRoute.ControllerRoute)]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly POSContext _context;
    public ItemController(POSContext context)
    {
        _context = context;
    }

    [HttpGet(ItemRoute.GetItems)]
    public async Task<ActionResult<List<CommonLibrary.Model.Item.Item>>> GetItems()
    {
        return await _context.Items.Where(e => e.IsActive)
        .Include(x => x.ItemCategory)
        .ToListAsync();
    }

    [HttpGet(ItemRoute.GetItem)]
    public async Task<ActionResult<CommonLibrary.Model.Item.Item>> GetItem(int id, bool includeDeleted = false)
    {
        CommonLibrary.Model.Item.Item? item = await _context.Items
        .FirstOrDefaultAsync(e => e.ItemId == id && e.IsActive != includeDeleted);

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost(ItemRoute.CreateItem)]
    public async Task<IActionResult> CreateItem(CommonLibrary.Model.Item.Item item)
    {
        item.IsActive = true;
        _context.Entry(item).State = EntityState.Added;
        await _context.SaveChangesAsync();
        CommonLibrary.Model.Item.ItemPriceHistory priceHistory = new()
        {
            Price = item.Price,
            Timestamp = DateTime.Now,
            ItemId = item.ItemId
        };
        _context.Entry(priceHistory).State = EntityState.Added;
        await _context.SaveChangesAsync();
        item.ItemPriceHistories.Clear();
        item.ItemCategory = new();

        return CreatedAtAction(nameof(CreateItem), new { id = item.ItemId }, item);
    }

    [HttpPut(ItemRoute.UpdateItem)]
    public async Task<IActionResult> UpdateItem(CommonLibrary.Model.Item.Item item)
    {
        CommonLibrary.Model.Item.Item? dbItem = await _context.Items.FirstOrDefaultAsync(e => e.ItemId == item.ItemId);

        if (dbItem == null)
        {
            return NotFound();
        }

        _context.Entry(item).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        if (dbItem.Price != item.Price)
        {
            CommonLibrary.Model.Item.ItemPriceHistory itemPriceHistory = new()
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

    [HttpDelete(ItemRoute.DeleteItem)]
    public async Task<IActionResult> DeleteItem(int id)
    {
        if (_context.Items == null)
        {
            return NotFound();
        }
        CommonLibrary.Model.Item.Item? item = await _context.Items.FindAsync(id);
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
