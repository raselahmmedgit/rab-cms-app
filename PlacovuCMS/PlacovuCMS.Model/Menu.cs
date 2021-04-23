using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.Model
{
    public partial class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Item { get; set; }
        public DateTime AddedOn { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
