using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_API.Models;

namespace POS_API.Controllers.Customer;

[Route("api/[controller]")]
[ApiController]
public class ContactNumberTypeController : ControllerBase
{
    private readonly POSContext _context;
    public ContactNumberTypeController(POSContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommonLibrary.Model.Customer.ContactNumberType>>> GetCustomerNumberTypes()
    {
        if (_context.ContactNumbers == null)
        {
            return NotFound();
        }


        List<CommonLibrary.Model.Customer.ContactNumberType> reference = await _context.ContactNumberTypes
        .Where(e => e.IsActive)
        .ToListAsync();

        if (reference.Count == 0)
        {
            return NotFound();
        }

        return reference;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContactNumberType(CommonLibrary.Model.Customer.ContactNumberType contactNumberType)
    {
        if (_context.Customers == null)
        {
            return Problem("Entity Customer does not exist");
        }

        await _context.ContactNumberTypes.AddAsync(contactNumberType);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetCustomer", new { id = contactNumberType.ContactNumberTypeId }, contactNumberType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContactNumberType(int id, CommonLibrary.Model.Customer.ContactNumberType contactNumberType)
    {
        if (id != contactNumberType.ContactNumberTypeId)
        {
            return BadRequest();
        }

        _context.Entry(contactNumberType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContactNumberTypeExists(id))
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
    public async Task<IActionResult> DeleteContactNumberType(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        CommonLibrary.Model.Customer.CustomerAddress? contactNumberType = await _context.CustomerAddresses.FindAsync(id);
        if (contactNumberType == null)
        {
            return NotFound();
        }

        contactNumberType.IsActive = false;

        _context.Entry(contactNumberType).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ContactNumberTypeExists(int id)
    {
        return (_context.ContactNumberTypes?.Any(e => e.ContactNumberTypeId == id)).GetValueOrDefault();
    }
}
