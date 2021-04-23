using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using PlacovuCMS.Core.Models;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Model;
using PlacovuCMS.Repository;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace PlacovuCMS.Manager
{
    public class EmailSenderManager : IEmailSenderManager
    {

        private readonly IContactUsConfigRepository _iContactUsConfigRepository;
        private readonly IEmailSmsConfigRepository _iEmailSmsConfigRepository;
        public EmailSenderManager(IContactUsConfigRepository iContactUsConfigRepository, IEmailSmsConfigRepository iEmailSmsConfigRepository)
        {
            _iContactUsConfigRepository = iContactUsConfigRepository;
            _iEmailSmsConfigRepository = iEmailSmsConfigRepository;
        }

        public async Task<EmailSentResult> ContactSendEmailToAdmin(ContactSendMessage contactSendMessage)
        {
            try
            {
                string emailTitle = $"City Glass - Contact Us - {contactSendMessage.ContactSubject}";
                string emailSubject = emailTitle;
                string emailTemplate = EmailTemplateHelper.GetContactSendMessageEmailTemplate(emailTitle, contactSendMessage: contactSendMessage);

                var ContactUsConfig = await _iContactUsConfigRepository.GetContactUsConfigFirstOrDefaultAsync();
                string emailAddressDisplayName = ContactUsConfig.FromEmailAddressDisplayName;
                string emailAddress = contactSendMessage.RecipientEmail;

                EmailMessage emailMessage = new EmailMessage();
                emailMessage.ReceiverName = emailAddressDisplayName;
                emailMessage.ReceiverEmail = emailAddress;
                emailMessage.Subject = emailSubject;
                emailMessage.IsHtml = true;
                emailMessage.Body = emailTemplate;

                var emailSentResult = await SendEmailMessage(emailMessage, "contactUsUser");

                if (!string.IsNullOrEmpty(ContactUsConfig.TestEmailAddress))
                {
                    string[] testEmailAddressList = ContactUsConfig.TestEmailAddress.Split(",");
                    foreach (var testEmailAddress in testEmailAddressList)
                    {
                        string[] testEmailAddressReceiverEmailAndNameList = testEmailAddress.Split("_");
                        EmailMessage testEmailMessage = new EmailMessage();
                        testEmailMessage.ReceiverName = testEmailAddressReceiverEmailAndNameList[0].ToString();
                        testEmailMessage.ReceiverEmail = testEmailAddressReceiverEmailAndNameList[1].ToString();
                        testEmailMessage.Subject = emailSubject;
                        testEmailMessage.IsHtml = true;
                        testEmailMessage.Body = emailTemplate;

                        var testEmailSentResult = await SendEmailMessage(testEmailMessage, "contactUsUser");
                    }
                }

                return emailSentResult;
            }
            catch (Exception ex)
            {
                return new EmailSentResult { Success = false, Ex = ex };
            }
        }

        public async Task<EmailSentResult> SendEmailMessage(EmailMessage emailMessage, string userId)
        {
            EmailSentResult emailSentResult = new EmailSentResult() { Success = false };
            try
            {
                var emailSmsConfig = await _iEmailSmsConfigRepository.GetEmailSmsConfigFirstOrDefaultAsync();
                var smtp = new SmtpClient
                {
                    Host = emailSmsConfig.Host,
                    Port = Convert.ToInt32(emailSmsConfig.Port),
                    EnableSsl = Convert.ToBoolean(emailSmsConfig.AllowSsl),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailSmsConfig.FromEmailAddress, emailSmsConfig.Password)
                };
                using (var smtpMessage = new MailMessage(new MailAddress(emailSmsConfig.FromEmailAddress, emailSmsConfig.FromEmailAddressDisplayName)
                    , new MailAddress(emailMessage.ReceiverEmail, emailMessage.ReceiverName)))
                {
                    smtpMessage.Subject = emailMessage.Subject;
                    smtpMessage.Body = emailMessage.Body;
                    smtpMessage.IsBodyHtml = emailMessage.IsHtml;
                    smtpMessage.Priority = MailPriority.Normal;
                    smtpMessage.SubjectEncoding = Encoding.UTF8;
                    smtpMessage.BodyEncoding = Encoding.UTF8;
                    smtpMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

                    smtp.Send(smtpMessage);

                    emailSentResult.Success = true;
                    emailSentResult.Id = userId;

                    smtp.Dispose();
                }
            }
            catch (Exception ex)
            {
                emailSentResult.Ex = ex;
            }
            await Task.FromResult(0);
            return emailSentResult;
        }
    }

    public interface IEmailSenderManager
    {
        Task<EmailSentResult> ContactSendEmailToAdmin(ContactSendMessage contactSendMessage);
        Task<EmailSentResult> SendEmailMessage(EmailMessage emailMessage, string userId);
    }
}
