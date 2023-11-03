using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;

namespace POS_API;

[Route("api/[controller]")]
[ApiController]
public class ItemPriceHistoryController : ControllerBase
{
    private readonly POSContext _context;
    public ItemPriceHistoryController(POSContext context)
    {
        _context = context;
    }

    [HttpGet("{itemId}")]
    public async Task<ActionResult<List<CommonLibrary.Model.Item.ItemPriceHistory>>> GetItemPriceHistory(int itemId)
    {
        if (_context.ItemPriceHistories == null)
        {
            return NotFound();
        }

        return await _context.ItemPriceHistories.Where(e => e.ItemId == itemId).ToListAsync();
    }
}
