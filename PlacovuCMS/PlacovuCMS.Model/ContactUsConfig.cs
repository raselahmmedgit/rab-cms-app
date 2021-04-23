using System.ComponentModel.DataAnnotations;

namespace PlacovuCMS.Model
{
    public partial class ContactUsConfig
    {
        public int Id { get; set; }
        public string ContactUsConfigType { get; set; }
        [Required]
        public string ToEmailAddress { get; set; }
        [Required]
        public string FromEmailAddress { get; set; }
        public string FromEmailAddressDisplayName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string PhoneNumberDisplayName { get; set; }
        public string TestEmailAddress { get; set; }
        public int DisplayOrder { get; set; }

    }
}
