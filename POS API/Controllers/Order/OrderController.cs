using CommonLibrary.Model.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;

namespace POS_API;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly POSContext _context;
    public OrderController(POSContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetOrders(int statusId = 0, int maxResult = 30, int customerId = 0)
    {
        if (_context.OrderPaymentMethods == null)
        {
            return NotFound();
        }

        if (maxResult < 1)
        {
            return BadRequest();
        }

        IQueryable<Order> order = _context.Orders;

        if (statusId > 0)
        {
            order = order.Where(e => e.OrderStatusId == statusId);
        }

        if (customerId > 0)
        {
            order = order.Where(e => e.CustomerId == customerId);
        }

        return await order.Take(maxResult).ToListAsync();
    }

    [HttpGet("{orderNumber}")]
    public async Task<ActionResult<Order>> GetCustomerOrder(string orderNumber)
    {
        if (_context.OrderPaymentMethods == null)
        {
            return NotFound();
        }

        Order? order = await _context.Orders
        .Include(e => e.OrderContents)
        .Include(e => e.OrderStatus)
        .Include(e => e.OrderPayments)
        .FirstOrDefaultAsync(e => e.OrderNumber == orderNumber);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        if (_context.Orders == null)
        {
            return Problem("Entity Order does not exist");
        }

        string? x = _context.Orders.Where(z => z.OrderNumber
        .StartsWith(DateTime.Now.Year.ToString()))
        .Max(e => e.OrderNumber.Substring(0, 5));

        int orderNumber = 0;
        if (x != null)
        {
            orderNumber = int.Parse(x);
        }

        order.OrderNumber = GenerateOrderNumber(orderNumber);

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        await _context.OrderContents.AddRangeAsync(order.OrderContents);
        await _context.OrderPayments.AddRangeAsync(order.OrderPayments);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, Order order)
    {
        if (id != order.OrderId)
        {
            return BadRequest();
        }

        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private string GenerateOrderNumber(int orderNumber)
    {
        return $"{DateTime.Now.Year}-{orderNumber:00000}";
    }
}
