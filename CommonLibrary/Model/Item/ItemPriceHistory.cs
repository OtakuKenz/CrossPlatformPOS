using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary.Model.Item;

/// <summary>
/// Item Price History
/// </summary>
public class ItemPriceHistory
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ItemPriceHistoryId { get; set; }

    /// <summary>
    /// Foreign key for <see cref="Model.Item.Item"/>.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Item.Item"/>.
    /// </summary>
    public Item Item { get; set; } = null!;

    public decimal Price { get; set; }

    /// <summary>
    /// Date and time when the record was added
    /// </summary>
    public DateTime Timestamp { get; set; }
}
