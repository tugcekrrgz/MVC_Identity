using System.ComponentModel.DataAnnotations;

namespace MVC_Identity.Models.DTO
{
    public class LoginDTO
    {
        
            [Required(ErrorMessage = "Şifre Zorunlu!")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Email  Zorunlu!")]
            public string Email { get; set; }
        }
    }
