using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;
using CommonLibrary.APIRoutes.Item;

namespace POS_API.Controllers.Item;

[Route(ItemPriceHistoryRoute.ControllerRoute)]
[ApiController]
public class ItemPriceHistoryController : ControllerBase
{
    private readonly POSContext _context;
    public ItemPriceHistoryController(POSContext context)
    {
        _context = context;
    }

    [HttpGet(ItemPriceHistoryRoute.GetItemPriceHistory)]
    public async Task<ActionResult<List<CommonLibrary.Model.Item.ItemPriceHistory>>> GetItemPriceHistory(int itemId)
    {
        return await _context.ItemPriceHistories.Where(e => e.ItemId == itemId).ToListAsync();
    }
}
