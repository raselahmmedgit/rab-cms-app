using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.ViewModel
{
    public partial class SiteInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Site Title")]
        public string SiteTitle { get; set; }

        [Display(Name = "Site Description")]
        public string SiteDescription { get; set; }

        [Display(Name = "Site Keywords")]
        public string SiteKeywords { get; set; }

        [Display(Name = "Site Author")]
        public string SiteAuthor { get; set; }

        [Display(Name = "Site Canonical Url")]
        public string SiteCanonicalUrl { get; set; }

        [Display(Name = "Site Shortlink Url")]
        public string SiteShortlinkUrl { get; set; }

        [Display(Name = "Site Url")]
        public string SiteUrl { get; set; }

        [Display(Name = "Site Image Url")]
        public string SiteImageUrl { get; set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

        [Display(Name = "Site Phone Number")]
        public string SitePhoneNumber { get; set; }

        [Display(Name = "Site Office Number")]
        public string SiteOfficeNumber { get; set; }

        [Display(Name = "Site Logo Url")]
        public string SiteLogoUrl { get; set; }

        [Display(Name = "Site Favicon16X16 Url")]
        public string SiteFavicon16X16Url { get; set; }

        [Display(Name = "Site Favicon32X32 Url")]
        public string SiteFavicon32X32Url { get; set; }

        [Display(Name = "Site Favicon180x180 Url")]
        public string SiteFavicon180x180Url { get; set; }

        [Display(Name = "Site Favicon192x192 Url")]
        public string SiteFavicon192x192Url { get; set; }

        [Display(Name = "Site Google Site Verification")]
        public string SiteGoogleSiteVerification { get; set; }
    }
}
