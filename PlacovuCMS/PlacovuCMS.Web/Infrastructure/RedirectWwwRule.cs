using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using System.Text;

namespace PlacovuCMS.Web.Infrastructure
{
    public class RedirectWwwRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;
            var currentScheme = req.Scheme;
            var currentHost = req.Host;
            if (!currentHost.Host.ToLower().StartsWith("www."))
            {
                RedirectRule(context, req, currentHost);
            }
            else if (!currentScheme.ToLower().StartsWith("https"))
            {
                RedirectRule(context, req, currentHost);
            }
        }

        private static void RedirectRule(RewriteContext context, HttpRequest req, HostString currentHost)
        {
            var newHost = new HostString(currentHost.Host, currentHost.Port ?? 443);
            var newUrl = new StringBuilder().Append("https://").Append("www.").Append(newHost).Append(req.PathBase).Append(req.Path).Append(req.QueryString);
            context.HttpContext.Response.Redirect(newUrl.ToString());
            context.Result = RuleResult.EndResponse;
        }
    }
}
