using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary;

/// <summary>
/// Order status.
/// </summary>
public class OrderStatus
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderStatusId { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    [Required]
    [MaxLength(length: 20, ErrorMessage = "Order status should not exceed 20 characters.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Order status description
    /// </summary>
    [Required]
    [MaxLength(length: 200, ErrorMessage = "Order status description should not exceed 200 characters.")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Is status still active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Status marked as true is required. Marking it as IsActive false or deleting it will cause runtime error.
    /// </summary>
    public bool IsSystemRequired { get; set; }
}
