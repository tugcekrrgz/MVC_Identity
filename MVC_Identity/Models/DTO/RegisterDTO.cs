using System.ComponentModel.DataAnnotations;//Validation işlmleeri için dahil ediliyor
namespace MVC_Identity.Models.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage="Kullanıcı Adı Zorunlu!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrarı Zorunlu!")]
        [Compare("Password",ErrorMessage="Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email  Zorunlu!")]
        public string Email { get; set; }
    }
}
