using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.App.Models
{
    public partial class AspNetUser : IdentityUser
    {
        public Country Country { get; set; }
        public int Age { get; set; }
    }

    public enum Country
    {
        USA, England, Bangladesh, Other
    }
}
