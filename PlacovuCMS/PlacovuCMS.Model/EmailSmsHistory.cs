namespace PlacovuCMS.Model
{
    public partial class EmailSmsHistory
    {
        public int Id { get; set; }
        public string ReciverName { get; set; }
        public string ReceiverEmailAddress { get; set; }
        public string EmailTemplateId { get; set; }
        public string EmailTemplateTypeId { get; set; }
        public string EmailTemplateTitle { get; set; }
        public string EmailTemplateDetail { get; set; }
        public int EmailSentStatus { get; set; }
        public int EmailSentFailedCount { get; set; }
        public string EmailSentMessage { get; set; }
        public int EmailResentCount { get; set; }
        public string EmailSentBy { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string SmsTemplateId { get; set; }
        public string SmsTemplateTypeId { get; set; }
        public string SmsTemplateTitle { get; set; }
        public string SmsTemplateDetail { get; set; }
        public int SmsSentStatus { get; set; }
        public int SmsSentFailedCount { get; set; }
        public string SmsSentMessage { get; set; }
        public int SmsResentCount { get; set; }
        public string SmsSentBy { get; set; }
    }
}
