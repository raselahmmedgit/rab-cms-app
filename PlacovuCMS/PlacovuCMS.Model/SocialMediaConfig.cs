using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.Model
{
    public partial class SocialMediaConfig
    {
        [Key]
        public int Id { get; set; }

        public string FacebookUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string TumblrUrl { get; set; }

        public string YouTubeUrl { get; set; }
    }
}
