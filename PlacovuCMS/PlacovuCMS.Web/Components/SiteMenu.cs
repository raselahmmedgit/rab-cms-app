using log4net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Manager;
using PlacovuCMS.ViewModel;
using PlacovuCMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Components
{
    public class SiteMenu : ViewComponent
    {
        #region Global Variable Declaration
        private readonly IMenuManager _iMenuManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public SiteMenu(IMenuManager iMenuManager)
        {
            _iMenuManager = iMenuManager;
            _log = LogManager.GetLogger(typeof(SiteMenu));
        }
        #endregion

        #region Actions
        public async Task<IViewComponentResult> InvokeAsync()
        {
            MenuViewModel menuViewModel = new MenuViewModel();
            try
            {
                var menuViewModelList = await _iMenuManager.GetMenusAsync();
                menuViewModel = menuViewModelList.Where(x => x.Name == "Main" && x.Status).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "InvokeAsync"));
            }
            return View((object)BindMenu(menuViewModel));
        }

        string BindMenu(MenuViewModel menuViewModel)
        {
            //json has [] therore changed the below code accordingly
            if (menuViewModel == null)
            {
                return "";
            }
            var rootObject = JsonConvert.DeserializeObject<List<MenuJsonRoot>>(menuViewModel.Item);
            string mainString = "<nav class='nav-menu d-none d-lg-block'>";
            mainString = mainString + "<ul>";

            for (int i = 0; i < rootObject.Count; i++)
            {
                var children = rootObject[i].children;
                if (children != null)
                {
                    string childString = "";
                    for (int j = 0; j < children.Count; j++)
                    {
                        childString = childString + CreateSubMenuItem(children[j]);
                    }
                    childString = "<ul>" + childString + "</ul>";

                    string parentString = "";
                    MenuJsonChild child = new MenuJsonChild();
                    child.deleted = rootObject[i].deleted;
                    child.@new = rootObject[i].@new;
                    child.slug = rootObject[i].slug;
                    child.name = rootObject[i].name;
                    child.id = rootObject[i].id;
                    parentString = CreateMenuItemWithSubMenu(child).Replace("</li>", "") + childString + "</li>";
                    mainString = mainString + parentString;
                }
                else
                {
                    string parentString = "";
                    MenuJsonChild child = new MenuJsonChild();
                    child.deleted = rootObject[i].deleted;
                    child.@new = rootObject[i].@new;
                    child.slug = rootObject[i].slug;
                    child.name = rootObject[i].name;
                    child.id = rootObject[i].id;

                    parentString = CreateMenuItem(child);
                    mainString = mainString + parentString;
                }
            }
            mainString = mainString + "</ul>";
            mainString = mainString + "</nav>";
            return mainString;
        }

        string CreateMenuItem(MenuJsonChild child)
        {
            //string childString = "<li class='nav-item'><a class='nav-link' href=\"/" + child.slug + "\">" + child.name + "</a></li>";
            string childString = "<li><a href=\"/" + child.slug + "\">" + child.name + "</a></li>";
            return childString;
        }

        string CreateMenuItemWithSubMenu(MenuJsonChild child)
        {
            //string childString = "<li class='nav-item dropdown'>"
            //    + "<a class='nav-link float-left' href=\"/" + child.slug + "\">" 
            //    + child.name 
            //    + "</a>"
            //    + "<button class='nav-pointer float-right pt-2 pb-2 dropdown-toggle' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'></button>"
            //    + "</li>";
            string childString = "<li class='drop-down'>"
                + "<div class='d-flex align-items-center'>"
                + "<span><a href=\"/" + child.slug + "\">"
                + child.name
                + "</a></span>"
                + "<span class='up-down'><button class='btn-nostyle'><i class='icofont-rounded-down'></i></button></span>"
                + "</div>"
                + "</li>";
            return childString;
        }

        string CreateSubMenuItem(MenuJsonChild child)
        {
            //string childString = "<a class='dropdown-item' href=\"/" + child.slug + "\">" + child.name + "</a>";
            string childString = "<a href=\"/" + child.slug + "\">" + child.name + "</a>";
            return childString;
        }

        #endregion
    }
}
