using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlacovuCMS.Core.Exception;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Manager;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;
using PlacovuCMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MenuController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IMenuManager _iMenuManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public MenuController(IMenuManager iMenuManager
            , IMapper iMapper
        )
        {
            _iMenuManager = iMenuManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(MenuController));
        }
        #endregion

        #region Actions
        // GET: Admin/Menu
        public IActionResult Index(int? id, string searchText, int? status)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<IActionResult> Add(int? id)
        {
            try
            {
                Menu menu = new Menu();
                if (id != null)
                {
                    menu = await _iMenuManager.GetMenuAsync(id.Value);
                    BindMenu(menu);
                    ViewBag.Title = "Update Menu";
                    return View(menu);
                }

                ViewBag.Title = "Add New Menu";
                return View(menu);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Menu menu, int? id)
        {
            try
            {
                ViewBag.Title = id == null ? "Add New Menu" : "Update Menu";

                if (ModelState.IsValid)
                {
                    _result = await _iMenuManager.AddOrEdit(menu, id);

                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "MenuMessage");
                        return RedirectToAction("Index", "Menu");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "MenuMessage");
                        ModelState.Clear();
                        BindMenu(menu);
                        return View(menu);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "MenuMessage");
                    return View(menu);
                }

            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "MenuMessage");
            return View(menu);
        }

        void BindMenu(Menu menu)
        {
            try
            {
                //json has [] therore changed the below code accordingly
                var rootObject = JsonConvert.DeserializeObject<List<MenuJsonRoot>>(menu.Item);
                string mainString = "<ol class=\"dd-list\">";

                for (int i = 0; i < rootObject.Count; i++)
                {
                    var children = rootObject[i].children;
                    if (children != null)
                    {
                        string childString = "";
                        for (int j = 0; j < children.Count; j++)
                            childString = childString + CreateMenuItem(children[j]);
                        childString = "<ol class=\"dd-list\">" + childString + "</ol>";

                        string parentString = "";
                        MenuJsonChild child = new MenuJsonChild();
                        child.deleted = rootObject[i].deleted;
                        child.@new = rootObject[i].@new;
                        child.slug = rootObject[i].slug;
                        child.name = rootObject[i].name;
                        child.id = rootObject[i].id;
                        parentString = CreateMenuItem(child).Replace("</li>", "") + childString + "</li>";
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
                mainString = mainString + "</ol>";
                ViewBag.Menu = mainString;
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "BindMenu"));
            }
        }

        string CreateMenuItem(MenuJsonChild child)
        {
            string childString = string.Empty;
            try
            {
                childString = "<li class=\"dd-item\" data-id=\"" + child.id + "\" data-name=\"" + child.name + "\" data-slug=\"" + child.slug + "\" data-new=\"" + child.@new + "\" data-deleted=\"" + child.deleted + "\"><div class=\"dd-handle\">" + child.name + "</div><span class=\"button-delete btn btn-default btn-xs pull-right\" data-owner-id=\"" + child.id + "\"><i class=\"fa fa-times-circle-o\" aria-hidden=\"true\"></i></span><span class=\"button-edit btn btn-default btn-xs pull-right\" data-owner-id=\"" + child.id + "\"><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></span></li>";
                return childString;
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "CreateMenuItem"));
            }
            return childString;
        }

        public string UpdateBulkStatus(string idChecked, string statusToChange)
        {
            string result = string.Empty;
            try
            {

                if (statusToChange == "Status")
                    result = "Select Status";
                else if (idChecked == null)
                    result = "Select at least 1 item";
                else
                {
                    using (var context = new AppDbContext())
                    {
                        var menu = context.Menu.Where(x => idChecked.Contains(x.Id.ToString())).ToList();
                        menu.ForEach(x => x.Status = Convert.ToBoolean(Convert.ToInt32(statusToChange)));
                        context.SaveChanges().ToString();
                        result = "Success";
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "UpdateBulkStatus"));
            }
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iMenuManager.DeleteMenuAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "MenuMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "MenuMessage");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Delete[POST]"));
                _result = Result.Fail(MessageHelper.UnhandelledError);
            }

            return JsonResult(_result);
        }

        [HttpGet]
        [Route("/Menu/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iMenuManager.GetDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }
        #endregion
    }
}