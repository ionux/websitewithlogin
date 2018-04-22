using System.ComponentModel.DataAnnotations;

namespace WebsiteWithLogin.ViewModels
{
    public class StudentRegisterViewModel
    {
        [Required, EmailAddress, MaxLength(256), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(30), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(30), DataType(DataType.Password), Display(Name = "Gentag password")]
        [Compare("Password", ErrorMessage = "Kodeord skal være ens")]
        public string PasswordConfirm { get; set; }
    }
}