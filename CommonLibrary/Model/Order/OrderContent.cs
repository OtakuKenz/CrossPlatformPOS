using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommonLibrary.Model.Item;

namespace CommonLibrary.Model.Order;

/// <summary>
/// Order Content
/// </summary>
public class OrderContent
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderContentId { get; set; }

    /// <summary>
    /// Foreign key for <see cref="Model.Order.Order"/>.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Order.Order"/>.
    /// </summary>
    public Order Order { get; set; } = null!;

    /// <summary>
    /// Foreign key for <see cref="Model.Item.Item"/>.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Item.Item"/>.
    /// </summary>
    public Item.Item Item { get; set; } = null!;

    /// <summary>
    /// Quantity for order.
    /// </summary>
    [Range(minimum: 1, maximum: double.PositiveInfinity, ErrorMessage = "Quantity should be atleast 1.")]
    public int Quantity { get; set; }

    /// <summary>
    /// Item price for the order
    /// </summary>
    [Required]
    public decimal Price { get; set; }
}
