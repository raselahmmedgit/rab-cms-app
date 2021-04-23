using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.Model
{
    public partial class SiteInfo
    {
        [Key]
        public int Id { get; set; }

        public string SiteTitle { get; set; }

        public string SiteDescription { get; set; }

        public string SiteKeywords { get; set; }

        public string SiteAuthor { get; set; }

        public string SiteCanonicalUrl { get; set; }

        public string SiteShortlinkUrl { get; set; }

        public string SiteUrl { get; set; }

        public string SiteImageUrl { get; set; }

        public string SiteName { get; set; }

        public string SitePhoneNumber { get; set; }

        public string SiteOfficeNumber { get; set; }

        public string SiteLogoUrl { get; set; }

        public string SiteFavicon16X16Url { get; set; }

        public string SiteFavicon32X32Url { get; set; }

        public string SiteFavicon180x180Url { get; set; }

        public string SiteFavicon192x192Url { get; set; }

        public string SiteGoogleSiteVerification { get; set; }
    }
}
