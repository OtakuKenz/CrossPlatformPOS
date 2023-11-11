using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommonLibrary.Model.Item;

/// <summary>
/// Item Category
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class ItemCategory
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ItemCategoryId { get; set; }

    /// <summary>
    /// Category name.
    /// </summary>
    [Required]
    [MaxLength(length: 50, ErrorMessage = "Item category name should not exceed 50 characters.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Is contact number type active.
    /// </summary>
    public bool IsActive { get; set; }
}
