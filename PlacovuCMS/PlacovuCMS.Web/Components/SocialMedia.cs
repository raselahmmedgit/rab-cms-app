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
    public class SocialMediaHeader : ViewComponent
    {
        #region Global Variable Declaration
        private readonly ISocialMediaConfigManager _iSocialMediaConfigManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public SocialMediaHeader(ISocialMediaConfigManager iSocialMediaConfigManager)
        {
            _iSocialMediaConfigManager = iSocialMediaConfigManager;
            _log = LogManager.GetLogger(typeof(SocialMediaHeader));
        }
        #endregion

        #region Actions
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SocialMediaConfigViewModel socialMediaConfigViewModel = new SocialMediaConfigViewModel();
            try
            {
                socialMediaConfigViewModel = await GetSocialMediaConfig();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "InvokeAsync"));
            }
            return View(socialMediaConfigViewModel);
        }

        public async Task<SocialMediaConfigViewModel> GetSocialMediaConfig()
        {
            SocialMediaConfigViewModel socialMediaConfigViewModel = new SocialMediaConfigViewModel();
            try
            {
                socialMediaConfigViewModel = await _iSocialMediaConfigManager.GetSocialMediaConfigAsync();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetSocialMediaConfig"));
            }
            return socialMediaConfigViewModel;
        }
        #endregion
    }

    public class SocialMediaFooter : ViewComponent
    {
        #region Global Variable Declaration
        private readonly ISocialMediaConfigManager _iSocialMediaConfigManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public SocialMediaFooter(ISocialMediaConfigManager iSocialMediaConfigManager)
        {
            _iSocialMediaConfigManager = iSocialMediaConfigManager;
            _log = LogManager.GetLogger(typeof(SocialMediaFooter));
        }
        #endregion

        #region Actions
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SocialMediaConfigViewModel socialMediaConfigViewModel = new SocialMediaConfigViewModel();
            try
            {
                socialMediaConfigViewModel = await GetSocialMediaConfig();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "InvokeAsync"));
            }
            return View(socialMediaConfigViewModel);
        }

        public async Task<SocialMediaConfigViewModel> GetSocialMediaConfig()
        {
            SocialMediaConfigViewModel socialMediaConfigViewModel = new SocialMediaConfigViewModel();
            try
            {
                socialMediaConfigViewModel = await _iSocialMediaConfigManager.GetSocialMediaConfigAsync();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetSocialMediaConfig"));
            }
            return socialMediaConfigViewModel;
        }
        #endregion
    }
}
