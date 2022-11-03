using System.ComponentModel.DataAnnotations;

namespace Teknoapp.webui.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Ad zorunlu bir alan.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunlu bir alan.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunlu bir alan.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre zorunlu bir alan.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreler uyuşmuyor.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "E-mail zorunlu bir alan.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }
}
