using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models{
    public class Payment{
        [Key]
        public int PaymentId { get; set; }
        public string OrderDate { get; set; }
        public string DelieveryDate { get; set; }
        public int OrderId { get; set; }
        public decimal Total_Amount { get; set; }
        public string Payment_Status { get; set; }
        public string Payment_Method { get; set; }
    }
}