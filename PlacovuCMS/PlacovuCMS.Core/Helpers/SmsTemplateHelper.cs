using System;
using System.Collections.Generic;
using System.Text;

namespace PlacovuCMS.Core.Helpers
{
    public static class SmsTemplateHelper
    {
        public static string GetSmsTemplate(string url)
        {
            string template = $"You have been massege. {url}";
            return template;
        }
    }
}
