using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary.Model.Order;

/// <summary>
/// Order payment.
/// </summary>
public class OrderPayment
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderPaymentId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Order.OrderPaymentMethod"/>.
    /// </summary>
    [Required]
    public int OrderPaymentMethodId { get; set; }

    /// <summary>
    /// Foreign Key for <see cref="Model.Order.OrderPaymentMethod"/>.
    /// </summary>
    public OrderPaymentMethod OrderPaymentMethod { get; set; } = null!;

    /// <summary>
    /// Reference to <see cref="Model.Order.Order"/>.
    /// </summary>
    [Required]
    public int OrderId { get; set; }

    /// <summary>
    /// Reference to <see cref="Model.Order.Order"/>.
    /// </summary>
    public Order Order { get; set; } = null!;

    /// <summary>
    /// Payment amount.
    /// </summary>
    [Range(0, double.PositiveInfinity)]
    public decimal Amount { get; set; }

    /// <summary>
    /// Payment reference number.
    /// </summary>
    [MaxLength(length: 20)]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Timestamp when payment was recorded.
    /// </summary>
    public DateTime Timestamp { get; set; }
}
