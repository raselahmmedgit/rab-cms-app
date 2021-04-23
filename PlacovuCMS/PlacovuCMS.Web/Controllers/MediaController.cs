using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Web.Infrastructure;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using AutoMapper;
using log4net;
using PlacovuCMS.Manager;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Utility;
using PlacovuCMS.Core.Exception;

namespace PlacovuCMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MediaController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IMediaManager _iMediaManager;
        private readonly ICommonSpAccessManager _iCommonSpAccessManager;
        private IWebHostEnvironment _iWebHostEnvironment;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public MediaController(IMediaManager iMediaManager
            ,ICommonSpAccessManager commonSpAccessManager
            , IWebHostEnvironment iWebHostEnvironment
            , IMapper iMapper
        )
        {
            _iMediaManager = iMediaManager;
            _iCommonSpAccessManager = commonSpAccessManager;
            _iWebHostEnvironment = iWebHostEnvironment;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(MediaController));
        }
        #endregion

        #region Actions
        public IActionResult Index()
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

        //[HttpPost]
        //public IActionResult Index(PlacovuCMS.Model.Media mMedia, string date)
        //{
        //    mMedia.MediaDate = GetMediaDate();
        //    return View(mMedia);
        //}

        public IActionResult Add()
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

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile[] mediaUpload)
        {
            List<FileUpload> lFileUpload = new List<FileUpload>();
            try
            {
                if (mediaUpload[0] == null)
                {
                    //ViewBag.Result = "No Files Selected";
                    _result = Result.Fail(MessageHelper.FilesNoSelected);
                    this.FlashError(_result.Error, "MediaMessage");
                    return View(lFileUpload);
                }
                else
                {
                    foreach (IFormFile file in mediaUpload)
                    {
                        FileUpload fileUpload = new FileUpload();
                        /*Start inserting of the files*/
                        string[] resultInsert = await _iMediaManager.InsertMediaAsync(file, null, null);
                        string resultUpload = "";
                        if (resultInsert[0] == "Success.")
                        {
                            resultUpload = await UploadMedia(file, resultInsert[1]);
                        }
                        /*End*/

                        fileUpload.name = file.FileName;
                        fileUpload.id = Convert.ToInt32(resultInsert[2]);

                        string savedPath150x150 = "";
                        bool isImage = ImageHelper.IsImage(file.FileName);
                        if (isImage)
                        {
                            savedPath150x150 = "~/" + ImageHelper.GetPath() + resultInsert[1];// remove this line when doing cropping

                            //Start the Cropping of Image
                            Dictionary<string, bool> dictionary =  ImageHelper.CheckFileCropApplicable(file);
                            string originalFileName = resultInsert[1];
                            string newFileName150x150 = originalFileName.Substring(0, originalFileName.LastIndexOf('.')) + "150X150" + originalFileName.Substring(originalFileName.LastIndexOf('.'), originalFileName.Length - originalFileName.LastIndexOf('.'));
                            string newFileName250x250 = originalFileName.Substring(0, originalFileName.LastIndexOf('.')) + "250X250" + originalFileName.Substring(originalFileName.LastIndexOf('.'), originalFileName.Length - originalFileName.LastIndexOf('.'));
                            string newFileName500x500 = originalFileName.Substring(0, originalFileName.LastIndexOf('.')) + "500X500" + originalFileName.Substring(originalFileName.LastIndexOf('.'), originalFileName.Length - originalFileName.LastIndexOf('.'));
                            string newFileName800x600 = originalFileName.Substring(0, originalFileName.LastIndexOf('.')) + "800X600" + originalFileName.Substring(originalFileName.LastIndexOf('.'), originalFileName.Length - originalFileName.LastIndexOf('.'));

                            foreach (var item in dictionary)
                            {
                                if ((item.Key == "Crop150") && (item.Value == true))
                                {
                                    resultInsert = await _iMediaManager.InsertMediaAsync(file, newFileName150x150, fileUpload.id);
                                    savedPath150x150 = ImageHelper.CropImage(_iWebHostEnvironment.WebRootPath, ImageHelper.GetPath(), originalFileName, resultInsert[1], 150, 150, true);
                                }
                                else if ((item.Key == "Crop250") && (item.Value == true))
                                {
                                    resultInsert = await _iMediaManager.InsertMediaAsync(file, newFileName250x250, fileUpload.id);
                                    ImageHelper.CropImage(_iWebHostEnvironment.WebRootPath, ImageHelper.GetPath(), originalFileName, resultInsert[1], 250, 250, true);
                                }
                                else if ((item.Key == "Crop500") && (item.Value == true))
                                {
                                    resultInsert = await _iMediaManager.InsertMediaAsync(file, newFileName500x500, fileUpload.id);
                                    ImageHelper.CropImage(_iWebHostEnvironment.WebRootPath, ImageHelper.GetPath(), originalFileName, resultInsert[1], 500, 500, true);
                                }
                                else if ((item.Key == "Crop800X600") && (item.Value == true))
                                {
                                    resultInsert = await _iMediaManager.InsertMediaAsync(file, newFileName800x600, fileUpload.id);
                                    ImageHelper.CropImage(_iWebHostEnvironment.WebRootPath, ImageHelper.GetPath(), originalFileName, resultInsert[1], 800, 600, true);
                                }
                            }
                            //End
                        }
                        fileUpload.url = savedPath150x150 == "" ? AppConstants.DefaultImagePath : savedPath150x150;
                        lFileUpload.Add(fileUpload);
                    }
                }
                if (lFileUpload.Count > 0)
                {
                    //ViewBag.Result = lFileUpload.Count + " Files Uploaded Successfully.";
                    string filesUploadedMessage = string.Format(MessageHelper.FilesUploaded, lFileUpload.Count);
                    _result = Result.Ok(filesUploadedMessage);
                    this.FlashSuccess(filesUploadedMessage, "MediaMessage");
                    return View(lFileUpload);
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }

            this.FlashError(MessageHelper.UnhandelledError, "MediaMessage");
            return View(lFileUpload);
        }

        public async Task<IActionResult> Edit(int id)
        {
            MediaViewModel mediaViewModel = new MediaViewModel();
            try
            {
                mediaViewModel = await _iMediaManager.GetMediaByIdAsync(id, _iWebHostEnvironment.WebRootPath);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
            return View(mediaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MediaViewModel mediaViewModel)
        {
            try
            {
                if (ImageHelper.IsImage(mediaViewModel.Name))
                {
                    mediaViewModel.DisplayUrl = mediaViewModel.Url;
                }
                else
                {
                    mediaViewModel.DisplayUrl = "admin/images/file-icon.png";
                }

                if (ModelState.IsValid)
                {
                    var result = await _iMediaManager.UpdateMediaAsync(mediaViewModel);

                    if (result == "Updated Successfully.")
                    {
                        _result = Result.Ok(result);
                        this.FlashSuccess(MessageHelper.Save, "MediaMessage");
                        return RedirectToAction("Index", "Media");
                    }
                    else
                    {
                        _result = Result.Fail(result);
                        this.FlashError(_result.Error, "Media");
                        return View(mediaViewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "MediaMessage");
                    return View(mediaViewModel);
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<string> DeleteMedia(string ids, string paths)
        {
            try
            {
                await _iMediaManager.DeleteMediaAsync(ids);
                foreach (string path in paths.Split(','))
                    System.IO.File.Delete(Path.Combine(_iWebHostEnvironment.WebRootPath, path.Substring(1)));
                return "Success.";
            }
            catch(Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "DeleteMedia"));
                return "Fail.";
            }
        }

        public async Task<string> GetMediaWithPaging(string fileType, string date, int page, string name)
        {
            //http://webdeveloperplus.com/jquery/create-a-dynamic-scrolling-content-box-using-ajax/ http://stackoverflow.com/questions/8480466/how-to-check-if-scrollbar-is-at-the-bottom
            //http://stackoverflow.com/questions/19933115/mvc-4-postback-on-dropdownlist-change
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                var result = await _iCommonSpAccessManager.GetMediaWithPaging(fileType, date, page, name);
                foreach (Media item in result)
                {
                    bool isImage = ImageHelper.IsImage(item.Name);
                    string url = "";
                    if (isImage)
                        url = item.ThumbUrl == null ? item.Url : item.ThumbUrl;
                    else
                        url = "admin/images/file-icon.png";
                    stringBuilder.Append("<li class=\"item\"><a href=\"" + Url.Action("Edit", new { id = item.Id }) + "\"><img data-url=\"/" + item.Url + "\" width =\"135\" src=\"" + Url.Content("~/" + url) + "\"/></a></li>");
                }
                return stringBuilder.ToString();
            }
            catch(Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetMediaWithPaging"));
                return string.Empty;
            }

        }

        public async Task<string> UploadMedia(IFormFile file, string fileName)
        {
            try
            {
                CommonFunction commonFunction = new CommonFunction(_iWebHostEnvironment);
                commonFunction.CreateUploadDirectory();
                string path = Path.Combine(_iWebHostEnvironment.WebRootPath, ImageHelper.GetPath() + fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return "Success.";
            }
            catch(Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "UploadMedia"));
                return "Fail.";
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var viewModel = await _iMediaManager.GetMediaAsync(id);
                if (id > 0)
                {
                    _result = await _iMediaManager.DeleteMediaAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    System.IO.File.Delete(Path.Combine(_iWebHostEnvironment.WebRootPath, viewModel.Url));
                    this.FlashSuccess(MessageHelper.Delete, "MediaMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "MediaMessage");
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
        [Route("/Media/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iMediaManager.GetDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

    }
    #endregion

}