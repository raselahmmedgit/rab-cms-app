using System;
using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.Model
{
    public partial class News
    {
        [Key]
        public int Id { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDetails { get; set; }
        public string NewsKeywords { get; set; }
    }
}
