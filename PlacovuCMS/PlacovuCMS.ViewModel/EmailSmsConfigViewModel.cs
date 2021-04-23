using System.ComponentModel;

namespace PlacovuCMS.ViewModel
{
    public partial class EmailSmsConfigViewModel
    {
        public int Id { get; set; }

        [DisplayName("Sender Email")]
        public string FromEmailAddress { get; set; }

        [DisplayName("Sender Name")]
        public string FromEmailAddressDisplayName { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Mail Host name")]
        public string Host { get; set; }

        [DisplayName("Mail Host Port")]
        public string Port { get; set; }

        [DisplayName("Allow SSL")]
        public bool AllowSsl { get; set; }

        [DisplayName("Sendgrid Sender Mail")]
        public string SendGridFromEmailAddress { get; set; }

        [DisplayName("Sendgrid Sender Name")]
        public string SendGridFromEmailAddressDisplayName { get; set; }

        [DisplayName("Sendgrid API Key")]
        public string SendGridApiKey { get; set; }

        [DisplayName("Test Mail")]
        public string TestEmailAddress { get; set; }

        [DisplayName("SMS Sender Phone Number")]
        public string SmsFromNumber { get; set; }

        [DisplayName("SMS Account Id")]
        public string SmsAccountSid { get; set; }

        [DisplayName("SMS Auth Token")]
        public string SmsAuthToken { get; set; }

        [DisplayName("Allow SMS")]
        public bool AllowSms { get; set; }

        [DisplayName("Allow Email")]
        public bool AllowEmail { get; set; }
    }
}