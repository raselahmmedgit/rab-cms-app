using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.ViewModel
{
    public partial class MediaViewModel
    {
        public MediaViewModel()
        {
            MediaDate = new List<SelectListItem>();
        }
        public int Id { get; set; }
        
        [Display(Name = "File Name")]
        public string Name { get; set; }

        [Display(Name = "File Url")]
        public string Url { get; set; }

        [Display(Name = "File Title")]
        public string Title { get; set; }

        [Display(Name = "File Alt")]
        public string Alt { get; set; }

        [Display(Name = "File Description")]
        public string Description { get; set; }

        [Display(Name = "File ThumbUrl")]
        public string ThumbUrl { get; set; }

        public List<SelectListItem> MediaDate { get; set; }
        public string Result { get; set; }
        public string DisplayUrl { get; set; }
        [Display(Name = "File Size")]
        public string FileSize { get; set; }
        [Display(Name = "File Type")]
        public string FileType { get; set; }
        [Display(Name = "File Dimension")]
        public string Dimension { get; set; }

        public int? ParentId { get; set; }
        [Display(Name = "Upload On")]
        public DateTime AddedOn { get; set; }
    }
}
