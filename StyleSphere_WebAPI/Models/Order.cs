using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        [Required]
        public decimal Total_Amount { get; set; } // Ensure this is decimal

        [Required]
        public decimal Shipping_Amount { get; set; } // Ensure this is decimal

        public decimal Discount_Amount { get; set; } // Ensure this is decimal

        [Required]
        public decimal Net_Amount { get; set; } // Ensure this is decimal

        [Required]
        public string Status { get; set; }

        public string Return_Reason { get; set; }

        [Required]
        public int ProdId { get; set; }
    }
}
