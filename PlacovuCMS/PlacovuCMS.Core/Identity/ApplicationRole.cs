using Microsoft.AspNetCore.Identity;

namespace PlacovuCMS.Core.Identity
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }

        public bool IsActive { get; set; }
    }
}
