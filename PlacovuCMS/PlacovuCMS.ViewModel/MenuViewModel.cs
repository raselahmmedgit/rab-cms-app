using System;
using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.ViewModel
{
    public partial class MenuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Menu Name")]
        public string Name { get; set; }

        [Display(Name = "Menu Items")]
        public string Item { get; set; }
        public DateTime AddedOn { get; set; }

        [Display(Name = "Menu Status")]
        public bool Status { get; set; }

        [Display(Name = "Menu Status")]
        public string StatusText => (Status == true ? "Active" : "In Active");
    }
}
