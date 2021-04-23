using System;
using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.ViewModel
{
    public class MenuModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? PrimaryImageId { get; set; }

        public string PrimaryImageUrl { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public bool Status { get; set; }

        [Display(Name = "Menu Status")]
        public string StatusText => (Status == true ? "Active" : "In Active");
    }
}
