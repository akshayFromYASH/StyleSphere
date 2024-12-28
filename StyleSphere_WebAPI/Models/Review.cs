using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models{
    public class ReviewandRating{
        [Key]
        public int Id { get; set; }
        public int ProdId { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
    }
}