using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models{
    public class User{
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string UserRole { get; set; }
    }
}