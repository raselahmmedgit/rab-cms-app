using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.ViewModel
{
    public partial class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
