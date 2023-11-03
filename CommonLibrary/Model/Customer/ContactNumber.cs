using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary.Model.Customer;

/// <summary>
/// Customer Contact Number
/// </summary>
public class ContactNumber
{
    /// <summary>
    /// Primary Key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContactNumberId { get; set; }

    /// <summary>
    /// Foreign key for <see cref="Model.Customer.Customer"/>.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Customer.Customer"/>.
    /// </summary>
    public Customer Customer { get; set; } = null!;

    /// <summary>
    /// Foreign Key for <see cref="Model.Customer.ContactNumberType"/>.
    /// </summary>
    public int ContactNumberTypeId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Customer.ContactNumberType"/>.
    /// </summary>
    public ContactNumberType ContactNumberType { get; set; } = null!;

    /// <summary>
    /// Customer contact Number.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Contact number is required.")]
    [StringLength(maximumLength: 11, MinimumLength = 7)]
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// The primary contact number.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Is Contact Number still Active
    /// </summary>
    public bool IsActive { get; set; }
}
