using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;

namespace POS_API;

[Route("api/[controller]")]
[ApiController]
public class OrderPaymentMethodController : ControllerBase
{
    private readonly POSContext _context;

    public OrderPaymentMethodController(POSContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommonLibrary.Model.Order.OrderPaymentMethod>>> GetOrderPaymentMethod()
    {
        if (_context.OrderPaymentMethods == null)
        {
            return NotFound();
        }

        return await _context.OrderPaymentMethods.Where(e => e.IsActive).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommonLibrary.Model.Order.OrderPaymentMethod>> GetOrderPaymentMethod(int id)
    {
        if (_context.OrderPaymentMethods == null)
        {
            return NotFound();
        }

        CommonLibrary.Model.Order.OrderPaymentMethod? reference = await _context.OrderPaymentMethods
        .Where(e => e.IsActive)
        .FirstOrDefaultAsync(e => e.OrderPaymentMethodId == id);

        if (reference == null)
        {
            return NotFound();
        }

        return reference;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderPaymentMethod(CommonLibrary.Model.Order.OrderPaymentMethod orderPaymentMethod)
    {
        if (_context.Customers == null)
        {
            return Problem("Entity Customer does not exist");
        }

        await _context.OrderPaymentMethods.AddAsync(orderPaymentMethod);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetOrderPaymentMethod", new { id = orderPaymentMethod.OrderPaymentMethodId }, orderPaymentMethod);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderPaymentMethod(int id, CommonLibrary.Model.Order.OrderPaymentMethod orderPaymentMethod)
    {
        if (id != orderPaymentMethod.OrderPaymentMethodId)
        {
            return BadRequest();
        }

        _context.Entry(orderPaymentMethod).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
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
    public async Task<IActionResult> DeleteOrderPaymentMethod(int id)
    {
        if (_context.OrderPaymentMethods == null)
        {
            return NotFound();
        }
        CommonLibrary.Model.Order.OrderPaymentMethod? orderPaymentMethod = await _context.OrderPaymentMethods.FindAsync(id);
        if (orderPaymentMethod == null)
        {
            return NotFound();
        }

        orderPaymentMethod.IsActive = false;

        _context.Entry(orderPaymentMethod).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerExists(int id)
    {
        return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
    }
}
