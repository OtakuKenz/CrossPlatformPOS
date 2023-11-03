using Microsoft.AspNetCore.Mvc;
using POS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace POS_API.Controllers.Customer;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly POSContext _context;

    public CustomerController(POSContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommonLibrary.Model.Customer.Customer>>> GetCustomers()
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }

        return await _context.Customers.Where(e => e.IsActive).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommonLibrary.Model.Customer.Customer>> GetCustomer(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }

        CommonLibrary.Model.Customer.Customer? reference = await _context.Customers
        .Include(e => e.ContactNumbers)
        .Include(e => e.Addresses)
        .Where(e => e.IsActive)
        .FirstOrDefaultAsync(e => e.CustomerId == id);

        if (reference == null)
        {
            return NotFound();
        }

        return reference;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CommonLibrary.Model.Customer.Customer customer)
    {
        if (_context.Customers == null)
        {
            return Problem("Entity Customer does not exist");
        }

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CommonLibrary.Model.Customer.Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return BadRequest();
        }

        _context.Entry(customer).State = EntityState.Modified;

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
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        CommonLibrary.Model.Customer.Customer? customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        customer.IsActive = false;

        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerExists(int id)
    {
        return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
    }
}
