using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommonLibrary.Model.Customer;

/// <summary>
/// Customer Contact Number Type
/// </summary>
[Index(nameof(Type), IsUnique = true)]
public class ContactNumberType
{
    /// <summary>
    /// Primary Key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContactNumberTypeId { get; set; }

    /// <summary>
    /// Type of contact number.
    /// This must be unique.
    /// </summary>
    [Required]
    [MaxLength(length: 50, ErrorMessage = "Contact number type should not exceed 50 characters.")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Is contact number type active.
    /// </summary>
    public bool IsActive { get; set; }
}