using System;
using System.ComponentModel;

namespace PlacovuCMS.ViewModel
{
    public partial class BlogViewModel
    {
        public int Id { get; set; }

        [DisplayName("Blog Category")]
        public int CategoryId { get; set; }

        [DisplayName("Image")]
        public int? PrimaryImageId { get; set; }

        [DisplayName("Image Url")]
        public string PrimaryImageUrl { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Blog url")]
        public string Url { get; set; }

        [DisplayName("Meta Title")]
        public string MetaTitle { get; set; }

        [DisplayName("Meta Keyword")]
        public string MetaKeyword { get; set; }

        [DisplayName("Meta Description")]
        public string MetaDescription { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Create Date")]
        public DateTime AddedOn { get; set; }
        public bool Status { get; set; }

        [DisplayName("Blog Status")]
        public string StatusText => (Status == true ? "Active" : "In Active");
    }
}