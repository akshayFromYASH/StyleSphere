using System.ComponentModel.DataAnnotations;

namespace StyleSphere.Models{
    public class LoginModel{
        public string Email { get; set; }

        [MinLength(8)]
        public string? Password {get;set;}
    }
}