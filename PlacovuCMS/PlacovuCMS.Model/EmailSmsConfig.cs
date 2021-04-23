namespace PlacovuCMS.Model
{
    public partial class EmailSmsConfig
    {
        public int Id { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromEmailAddressDisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public bool AllowSsl { get; set; }
        public string SendGridFromEmailAddress { get; set; }
        public string SendGridFromEmailAddressDisplayName { get; set; }
        public string SendGridApiKey { get; set; }
        public string TestEmailAddress { get; set; }
        public string SmsFromNumber { get; set; }
        public string SmsAccountSid { get; set; }
        public string SmsAuthToken { get; set; }
        public bool AllowSms { get; set; }
        public bool AllowEmail { get; set; }

    }
}
