using System.ComponentModel.DataAnnotations;

namespace S7.Models.ViewModels
{
    public class LoginViewModel
    {

        [EmailAddress]
        [Required]
        [MaxLength(40)]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(40)]
        [Display(Name = "password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = true;

    }
}
