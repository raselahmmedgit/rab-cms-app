using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Core.Identity;

namespace PlacovuCMS.Web.Data
{
    
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }
    }
}
