using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMS.App.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CMS.App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CMS.App.Components
{
    public class UserDetail: ViewComponent
    {
        private UserManager<AspNetUser> userManager;
        public UserDetail(UserManager<AspNetUser> userMgr)
        {
            userManager = userMgr;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //string userName = HttpContext.User.Identity.Name;
            return View(await GetUser());
        }

        public async Task<LoggedUser> GetUser()
        {
            AspNetUser user = await userManager.GetUserAsync(HttpContext.User);
            var roles = await userManager.GetRolesAsync(user);

            LoggedUser loggedUser = new LoggedUser();
            loggedUser.UserName = user.UserName;
            loggedUser.Role = roles.FirstOrDefault();
           
            return loggedUser;
        }
    }
}
