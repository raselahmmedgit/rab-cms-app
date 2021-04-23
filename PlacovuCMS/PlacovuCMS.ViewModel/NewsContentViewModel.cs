using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.ViewModel
{
    public partial class NewsContentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "News Title")]
        public string NewsTitle { get; set; }

        [Display(Name = "News Details")]
        public string NewsDetails { get; set; }

        [Display(Name = "News Keywords")]
        public string NewsKeywords { get; set; }

    }
}
