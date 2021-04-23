using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlacovuCMS.Core.Exception;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Manager;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Controllers
{
    public class NewsContentController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly INewsContentManager _iNewsContentManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public NewsContentController(INewsContentManager iNewsContentManager
            , IMapper iMapper
        )
        {
            _iNewsContentManager = iNewsContentManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(NewsContentController));
        }
        #endregion

        [HttpGet]
        [Route("/NewsContent/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iNewsContentManager.GetDataTablesResponseAsync(request);
                var result = new DataTablesJsonResult(response, true);
                return result;
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

        public IActionResult Index()
        {
            try
            {
                return View(new NewsContentViewModel());
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }


        public IActionResult Add()
        {
            try
            {
                var model = new NewsContentViewModel();
                if (model != null)
                {
                    return View("Add", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "NewsContentMessage");
                    return RedirectToAction("Index", "NewsContent");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "NewsContentMessage");
            return RedirectToAction("Index", "NewsContent");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _iNewsContentManager.GetNewsContentAsync(id);

                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "NewsContentMessage");
                    return RedirectToAction("Index", "NewsContent");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Edit[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "NewsContentMessage");
            return RedirectToAction("Index", "NewsContent");
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var configViewModel = await _iNewsContentManager.GetNewsContentAsync(id);

                if (configViewModel != null)
                {
                    return View("Details", configViewModel);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "NewsContentMessage");
                    return RedirectToAction("Index", "NewsContent");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Details[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "NewsContentMessage");
            return RedirectToAction("Index", "NewsContent");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(NewsContentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (viewModel.Id == 0)
                    {
                        _result = await _iNewsContentManager.InsertNewsContentAsync(viewModel);
                    }
                    else if (viewModel.Id > 0) //edit
                    {
                        _result = await _iNewsContentManager.UpdateNewsContentAsync(viewModel);
                    }

                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "NewsContentMessage");
                        return RedirectToAction("Index", "NewsContent");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "NewsContentMessage");
                        return View("Add",viewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "NewsContentMessage");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Save[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "NewsContentMessage");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iNewsContentManager.DeleteNewsContentAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "NewsContentMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "NewsContentMessage");
                }
                return JsonResult(_result);
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Delete[POST]"));
                _result = Result.Fail(MessageHelper.UnhandelledError);
                return JsonResult(_result);
            }
        }
    }
}
