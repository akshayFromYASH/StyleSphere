using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models{
    public class Cart{
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Cart_Amount { get; set; }
        
    }
}