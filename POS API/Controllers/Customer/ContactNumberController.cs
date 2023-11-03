using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;

namespace POS_API.Controllers.Customer;

[Route("api/Customer/[controller]")]
[ApiController]
public class ContactNumberController : ControllerBase
{
    private readonly POSContext _context;
    public ContactNumberController(POSContext context)
    {
        _context = context;
    }

    [HttpGet("{customerId}")]
    public async Task<ActionResult<List<CommonLibrary.Model.Customer.ContactNumber>>> GetCustomerNumber(int customerId)
    {
        if (_context.ContactNumbers == null)
        {
            return NotFound();
        }

        List<CommonLibrary.Model.Customer.ContactNumber> reference = await _context.ContactNumbers
        .Include(e => e.ContactNumberType)
        .Where(e => e.CustomerId == customerId && e.IsPrimary)
        .ToListAsync();

        if (reference.Count == 0)
        {
            return NotFound();
        }

        return reference;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContactNumber(CommonLibrary.Model.Customer.ContactNumber contactNumber)
    {
        if (_context.Customers == null)
        {
            return Problem("Entity Customer does not exist");
        }

        await _context.ContactNumbers.AddAsync(contactNumber);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetCustomer", new { id = contactNumber.ContactNumberId }, contactNumber);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContactNumber(int id, CommonLibrary.Model.Customer.ContactNumber contactNumber)
    {
        if (id != contactNumber.ContactNumberId)
        {
            return BadRequest();
        }

        _context.Entry(contactNumber).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContactNumberExist(id))
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
    public async Task<IActionResult> DeleteContact(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        CommonLibrary.Model.Customer.ContactNumber? contactNumber = await _context.ContactNumbers.FindAsync(id);
        if (contactNumber == null)
        {
            return NotFound();
        }

        contactNumber.IsActive = false;

        _context.Entry(contactNumber).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ContactNumberExist(int id)
    {
        return (_context.ContactNumbers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
    }
}
