using Microsoft.AspNetCore.Identity;

namespace PlacovuCMS.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public Country Country { get; set; }
        public int Age { get; set; }
    }

    public enum Country
    {
        USA, England, Bangladesh, Other
    }
}
