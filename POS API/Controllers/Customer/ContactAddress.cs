using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;

namespace POS_API.Controllers.Customer;

[Route("api/Customer/Address")]
[ApiController]
public class ContactAddress : ControllerBase
{
    private readonly POSContext _context;
    public ContactAddress(POSContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommonLibrary.Model.Customer.CustomerAddress>>> GetCustomersAddresses()
    {
        return await _context.CustomerAddresses.Where(e => e.IsActive).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommonLibrary.Model.Customer.CustomerAddress>> GetCustomerAddress(int id)
    {
        CommonLibrary.Model.Customer.CustomerAddress? reference = await _context.CustomerAddresses
        .FirstOrDefaultAsync(e => e.CustomerId == id);

        if (reference == null)
        {
            return NotFound();
        }

        return reference;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CommonLibrary.Model.Customer.CustomerAddress customerAddress)
    {
        await _context.CustomerAddresses.AddAsync(customerAddress);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetCustomerAddress", new { id = customerAddress.CustomerAddressId }, customerAddress);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CommonLibrary.Model.Customer.CustomerAddress customerAddress)
    {
        if (id != customerAddress.CustomerAddressId)
        {
            return BadRequest();
        }

        _context.Entry(customerAddress).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerAddressExist(id))
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
    public async Task<IActionResult> DeleteCustomerAddress(int id)
    {
        if (_context.CustomerAddresses == null)
        {
            return NotFound();
        }
        CommonLibrary.Model.Customer.CustomerAddress? customerAddress = await _context.CustomerAddresses.FindAsync(id);
        if (customerAddress == null)
        {
            return NotFound();
        }

        customerAddress.IsActive = false;

        _context.Entry(customerAddress).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerAddressExist(int id)
    {
        return (_context.CustomerAddresses?.Any(e => e.CustomerAddressId == id)).GetValueOrDefault();
    }
}