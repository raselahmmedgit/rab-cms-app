using log4net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Identity;
using PlacovuCMS.Core.Utility;
using PlacovuCMS.Manager;
using PlacovuCMS.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Components
{
    public class SiteLogo : ViewComponent
    {
        #region Global Variable Declaration
        private readonly ISiteInfoManager _iSiteInfoManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public SiteLogo(ISiteInfoManager iSiteInfoManager)
        {
            _iSiteInfoManager = iSiteInfoManager;
            _log = LogManager.GetLogger(typeof(SiteLogo));
        }
        #endregion

        #region Actions
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string siteLogoUrl = "";
            try
            {
                siteLogoUrl = await GetSiteLogo();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "InvokeAsync"));
            }
            return View((object)siteLogoUrl);
        }

        public async Task<string> GetSiteLogo()
        {
            string siteLogoUrl = "";
            try
            {
                siteLogoUrl = await _iSiteInfoManager.GetSiteLogoUrlAsync();
                if (string.IsNullOrEmpty(siteLogoUrl))
                {
                    siteLogoUrl = AppConstants.DefaultLogoPath;
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetSiteLogo"));
            }
            return BuildSiteLogo(siteLogoUrl);
        }

        string BuildSiteLogo(string logoUrl)
        {
            //string logoString = "<a class='navbar-brand' href='/home'>"
            //    + "<img src='/" + logoUrl + "' alt='home' class='img-logo'/>"
            //    +"</a>";
            string logoString = "<a class='logo' href='/home'>"
                + "<img src='/" + logoUrl + "' alt='home' class='img-fluid'/>"
                + "</a>";
            return logoString;
        }
        #endregion
    }
}
