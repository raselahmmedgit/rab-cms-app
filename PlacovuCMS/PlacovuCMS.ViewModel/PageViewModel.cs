using System;
using System.ComponentModel;

namespace PlacovuCMS.ViewModel
{
    public partial class PageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        [DisplayName("Meta Title")]
        public string MetaTitle { get; set; }
        [DisplayName("Meta Keyword")]
        public string MetaKeyword { get; set; }
        [DisplayName("Meta Description")]
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        [DisplayName("Added Date")]
        public DateTime AddedOn { get; set; }
        public bool Status { get; set; }

        [DisplayName("Page Status")]
        public string StatusText => (Status == true ? "Active" : "In Active");
    }
}
