using System.ComponentModel.DataAnnotations;

namespace S7.Models.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required]
        [MaxLength(40)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(40)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(40)]
        [Compare(nameof(Password))] 
        public string confirmPassword { get; set; }
        [Phone]
        [Required]
        [MaxLength(40)]
        public string Phone { get; set; }
    }
}
