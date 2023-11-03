using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary.Model.Order;

public class OrderPaymentMethod
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderPaymentMethodId { get; set; }

    /// <summary>
    /// Payment method.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Payment method name is required.")]
    [MaxLength(length: 20, ErrorMessage = "Payment method name should not exceed 20 characters.")]
    public string PaymentMethod { get; set; } = string.Empty;

    /// <summary>
    /// Is Payment method still active.
    /// </summary>
    public bool IsActive { get; set; }
}