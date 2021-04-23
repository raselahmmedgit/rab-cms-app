using log4net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Identity;
using PlacovuCMS.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Components
{
    public class UserDetail: ViewComponent
    {
        #region Global Variable Declaration
        private UserManager<ApplicationUser> _userManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public UserDetail(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _log = LogManager.GetLogger(typeof(UserDetail));
        }
        #endregion

        #region Actions
        public async Task<IViewComponentResult> InvokeAsync()
        {
            LoggedUserViewModel loggedUserViewModel = new LoggedUserViewModel();
            try
            {
                //string userName = HttpContext.User.Identity.Name;
                loggedUserViewModel = await GetUser();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "InvokeAsync"));
            }
            return View(loggedUserViewModel);
        }

        public async Task<LoggedUserViewModel> GetUser()
        {
            LoggedUserViewModel loggedUserViewModel = new LoggedUserViewModel();
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                var roles = await _userManager.GetRolesAsync(user);
                
                loggedUserViewModel.UserName = user?.UserName;
                loggedUserViewModel.Role = roles.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetUser"));
            }
            return loggedUserViewModel;
        }
        #endregion
    }
}
