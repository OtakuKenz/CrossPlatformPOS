using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommonLibrary.Model.Order;

/// <summary>
/// Order.
/// </summary>
[Index(nameof(OrderNumber), IsUnique = true)]
public class Order
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    /// <summary>
    /// Unique order number.
    /// </summary>
    [MaxLength(length: 10, ErrorMessage = "Order number should not be empty.")]
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key of customer who ordered.
    /// Reference to <see cref="Customer.Customer"/>.
    /// </summary>
    public int? CustomerId { get; set; }

    /// <summary>
    /// Customer who ordered.
    /// Reference to <see cref="Customer.Customer"/>.
    /// </summary>
    public Customer.Customer? Customer { get; set; }

    public ICollection<OrderContent> OrderContents { get; set; } = new List<OrderContent>();
    public ICollection<OrderPayment> OrderPayments { get; set; } = new List<OrderPayment>();

    /// <summary>
    /// Total Discount in the order.
    /// </summary>
    [Range(0, double.PositiveInfinity)]
    public decimal TotalDiscount { get; set; }

    /// <summary>
    /// The order total.
    /// </summary>
    [Range(0, double.PositiveInfinity)]
    public decimal Total { get; set; }

    /// <summary>
    /// Timestamp when order was placed.
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Foreign key of order stats.
    /// Reference to <see cref="OrderStatus"/>.
    /// </summary>
    public int OrderStatusId { get; set; }

    /// <summary>
    /// Order stats.
    /// Reference to <see cref="OrderStatus"/>.
    /// </summary>
    public OrderStatus OrderStatus { get; set; } = null!;
}
