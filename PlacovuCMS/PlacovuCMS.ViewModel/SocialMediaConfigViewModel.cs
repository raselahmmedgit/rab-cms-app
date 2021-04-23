using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.ViewModel
{
    public partial class SocialMediaConfigViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Facebook Url")]
        public string FacebookUrl { get; set; }

        [Display(Name = "Linked In Url")]
        public string LinkedInUrl { get; set; }

        [Display(Name = "Instagram Url")]
        public string InstagramUrl { get; set; }

        [Display(Name = "Twitter Url")]
        public string TwitterUrl { get; set; }

        [Display(Name = "Tumblr Url")]
        public string TumblrUrl { get; set; }

        [Display(Name = "YouTube Url")]
        public string YouTubeUrl { get; set; }
    }
}
