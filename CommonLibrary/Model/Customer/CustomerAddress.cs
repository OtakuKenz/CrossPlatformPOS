using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary.Model.Customer;

/// <summary>
/// Customer Address
/// </summary>
public class CustomerAddress
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerAddressId { get; set; }

    /// <summary>
    /// Full Address of customer
    /// </summary>
    [Required]
    public required string FullAddress { get; set; }

    /// <summary>
    /// Address landmark
    /// </summary>
    [MaxLength(length: 100, ErrorMessage = "Landmark should not exceed 100 characters.")]
    public string Landmark { get; set; } = string.Empty;

    /// <summary>
    /// Additional notes
    /// </summary>
    [MaxLength(length: 200, ErrorMessage = "Additional notes should not exceed 200 characters.")]
    public string AdditionalNotes { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key for <see cref="Model.Customer.Customer"/>.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Customer.Customer"/>.
    /// </summary>
    public Customer Customer { get; set; } = new();

    /// <summary>
    /// The primary contact number.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Is Address still active.
    /// </summary>
    public bool IsActive { get; set; }
}
