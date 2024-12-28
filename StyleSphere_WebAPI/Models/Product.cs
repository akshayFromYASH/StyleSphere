using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models{
    public class Product{
        [Key]
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Availaibility { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Stock_Quantity { get; set; }
    }
}