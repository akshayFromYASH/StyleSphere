using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Shipping_Amount { get; set; }
        public decimal Discount_Amount { get; set; }
        public decimal Net_Amount { get; set; }
        public string Status { get; set; }
        public string Return_Reason { get; set; }
        public int CartId { get; set; }

    }
}