using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary.Model.Customer;

/// <summary>
/// Customer
/// </summary>
public class Customer
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }

    /// <summary>
    /// First name of customer
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
    [MaxLength(length: 50, ErrorMessage = "First name should not exceed 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Middle name of customer
    /// </summary>
    [MaxLength(length: 50, ErrorMessage = "Middle name should not exceed 50 characters.")]
    public string MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Last name of customer
    /// </summary>
    [MaxLength(length: 50, ErrorMessage = "Last name should not exceed 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Customer contact numbers
    /// </summary>
    public ICollection<ContactNumber> ContactNumbers { get; } = new List<ContactNumber>();

    /// <summary>
    /// Customer addresses
    /// </summary>
    public ICollection<CustomerAddress> Addresses { get; } = new List<CustomerAddress>();

    /// <summary>
    /// Is customer still active.
    /// </summary>
    public bool IsActive { get; set; }
}