using CommonLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;

namespace POS_API;

[Route("api/[controller]")]
[ApiController]
public class OrderStatusController : ControllerBase
{
    private readonly POSContext _context;
    public OrderStatusController(POSContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderStatus>>> GetOrderStatuses()
    {
        if (_context.OrderStatuses == null)
        {
            return NotFound();
        }

        return await _context.OrderStatuses
        .Where(e => e.IsActive)
        .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderStatus>> GetOrderStatus(int id)
    {
        if (_context.OrderStatuses == null)
        {
            return NotFound();
        }

        OrderStatus? orderStatus = await _context.OrderStatuses.FirstOrDefaultAsync(e => e.IsActive && e.OrderStatusId == id);

        if (orderStatus == null)
        {
            return NotFound();
        }

        return orderStatus;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderStatus(OrderStatus orderStatus)
    {
        if (_context.OrderStatuses == null)
        {
            return Problem("Entity Order Status does not exist");
        }

        orderStatus.IsSystemRequired = false;
        orderStatus.IsActive = true;
        await _context.OrderStatuses.AddAsync(orderStatus);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetOrderStatus", new { id = orderStatus.OrderStatusId, orderStatus });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderStatus(int id, OrderStatus orderStatus)
    {
        if (_context.OrderStatuses == null)
        {
            return NotFound();
        }

        if (id != orderStatus.OrderStatusId)
        {
            return BadRequest();
        }

        OrderStatus? _orderStatus = await _context.OrderStatuses.FirstOrDefaultAsync(e => e.OrderStatusId == id);

        if (_orderStatus == null)
        {
            return BadRequest();
        }

        if (_orderStatus.IsSystemRequired)
        {
            return UnprocessableEntity(orderStatus);
        }

        _context.Entry(orderStatus).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok();
    }
}
