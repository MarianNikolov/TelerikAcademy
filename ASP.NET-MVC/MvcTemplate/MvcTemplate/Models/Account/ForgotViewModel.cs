using System.ComponentModel.DataAnnotations;

namespace MvcTemplate.Models.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}