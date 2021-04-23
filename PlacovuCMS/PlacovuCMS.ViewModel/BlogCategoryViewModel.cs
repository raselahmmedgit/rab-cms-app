using System;
using System.ComponentModel;

namespace PlacovuCMS.ViewModel
{
    public partial class BlogCategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Parent Id")]
        public int? ParentId { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Url")]
        public string Url { get; set; }

        [DisplayName("Meta Title")]
        public string MetaTitle { get; set; }

        [DisplayName("Meta Ketword")]
        public string MetaKeyword { get; set; }

        [DisplayName("Meta Description")]
        public string MetaDescription { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Create Date")]
        public DateTime AddedOn { get; set; }
        public bool Status { get; set; }

        [DisplayName("Blog Category Status")]
        public string StatusText => (Status == true ? "Active" : "In Active");
        public long totalBlogs { get; set; }
    }
}