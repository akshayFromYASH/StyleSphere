using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models{
    public class Shipping_Detail{
        [Key]
        public int ShippingId { get; set; }
        public int OrderId  { get; set; }
        public string ShippingTo { get; set; }
        public string ContactDetails { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public int ProdId { get; set; }
    }
}