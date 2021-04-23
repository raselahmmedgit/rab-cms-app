using System.ComponentModel;

namespace PlacovuCMS.ViewModel
{
    public partial class ContactUsConfigViewModel
    {
        public int Id { get; set; }

        [DisplayName("Configuration Type")]
        public string ContactUsConfigType { get; set; }

        [DisplayName("Receipient Email")]
        public string ToEmailAddress { get; set; }

        [DisplayName("Sender Email")]
        public string FromEmailAddress { get; set; }

        [DisplayName("Sender Name")]
        public string FromEmailAddressDisplayName { get; set; }

        [DisplayName("Receipient Phone")]
        public string PhoneNumber { get; set; }

        [DisplayName("Receipient Name")]
        public string PhoneNumberDisplayName { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}