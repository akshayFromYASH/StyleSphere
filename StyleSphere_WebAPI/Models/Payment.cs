using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models{
    public class Payment{
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public string OrderDate { get; set; }
        [Required]
        public string DelieveryDate { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public decimal Total_Amount { get; set; }
        [Required]
        public decimal Shipping_Amount { get; set; }
        [Required]
        public decimal Discount_Amount { get; set; }
        [Required]
        public decimal Pay_Amount { get; set; }
        [Required]
        public string Payment_Status { get; set; }
        [Required]
        public string Payment_Method { get; set; }
        [Required]
        public int ProdId { get; set; }
    }
}