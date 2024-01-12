using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary.Model.Item;

/// <summary>
/// Item
/// </summary>
public class Item
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ItemId { get; set; }

    /// <summary>
    /// Item name.
    /// </summary>
    [Required(ErrorMessage = "Item name is required.")]
    [MaxLength(length: 50, ErrorMessage = "Item name is required.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Item description.
    /// </summary>
    [MaxLength(length: 200, ErrorMessage = "Item description should not exceed 200 characters.")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key for <see cref="Model.Item.ItemCategory"/>.
    /// </summary>
    [Required(ErrorMessage = "Item Category is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Item Category is required.")]
    public int ItemCategoryId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Item.ItemCategory"/>.
    /// </summary>
    public virtual ItemCategory ItemCategory { get; set; } = new();

    /// <summary>
    /// Is Item Active.
    /// </summary>
    public bool IsActive { get; set; }

    [Range(0, double.PositiveInfinity)]
    public decimal Price { get; set; }

    public ICollection<ItemPriceHistory> ItemPriceHistories { get; set; } = new List<ItemPriceHistory>();
}
