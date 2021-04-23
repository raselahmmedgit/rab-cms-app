using log4net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Identity;
using PlacovuCMS.Manager;
using PlacovuCMS.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Components
{
    public class SiteMeta : ViewComponent
    {
        #region Global Variable Declaration
        private readonly ISiteInfoManager _iSiteInfoManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public SiteMeta(ISiteInfoManager iSiteInfoManager)
        {
            _iSiteInfoManager = iSiteInfoManager;
            _log = LogManager.GetLogger(typeof(SiteMeta));
        }
        #endregion

        #region Actions
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SiteInfoViewModel siteInfoViewModel = new SiteInfoViewModel();
            try
            {
                siteInfoViewModel = await GetSiteInfo();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "InvokeAsync"));
            }
            return View(siteInfoViewModel);
        }

        public async Task<SiteInfoViewModel> GetSiteInfo()
        {
            SiteInfoViewModel siteInfoViewModel = new SiteInfoViewModel();
            try
            {
                siteInfoViewModel = await _iSiteInfoManager.GetSiteInfoAsync();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetSiteInfo"));
            }
            return siteInfoViewModel;
        }
        #endregion
    }
}
