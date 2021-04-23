using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.ViewModel
{
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
    }
}
