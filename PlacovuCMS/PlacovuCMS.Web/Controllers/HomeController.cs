using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Core.Identity;
using PlacovuCMS.Manager;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private UserManager<ApplicationUser> _userManager;
        private readonly IBlogCategoryManager _iBlogCategoryManager;
        private readonly IBlogManager _iBlogManager;
        private readonly IMediaManager _iMediaManager;
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly IPageManager _iPageManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public HomeController(UserManager<ApplicationUser> userManager
            , IMapper iMapper
            , IBlogCategoryManager iBlogCategoryManager
            , IBlogManager iBlogManager
            , IMediaManager iMediaManager
            , IWebHostEnvironment iWebHostEnvironment
            , IPageManager iPageManager
        )
        {
            _userManager = userManager;
            _iMapper = iMapper;
            _iBlogCategoryManager = iBlogCategoryManager;
            _iBlogManager = iBlogManager;
            _iMediaManager = iMediaManager;
            _iWebHostEnvironment = iWebHostEnvironment;
            _iPageManager = iPageManager;
            _log = LogManager.GetLogger(typeof(HomeController));
        }
        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            try
            {
                PageViewModel pageViewModel = new PageViewModel();
                pageViewModel = await _iPageManager.GetPageByNameAsync("Home");
                if (pageViewModel != null)
                {
                    if (!string.IsNullOrEmpty(pageViewModel.MetaTitle))
                    {
                        ViewData["Title"] = pageViewModel.MetaTitle;
                    }
                    if (!string.IsNullOrEmpty(pageViewModel.MetaKeyword))
                    {
                        ViewData["Keywords"] = pageViewModel.MetaKeyword;
                    }
                    if (!string.IsNullOrEmpty(pageViewModel.MetaDescription))
                    {
                        ViewData["Description"] = pageViewModel.MetaDescription;
                    }
                    return View(pageViewModel);
                }
                else
                {
                    return ErrorNullView();
                }

            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<IActionResult> Page(string name)
        {
            try
            {
                PageViewModel pageViewModel = new PageViewModel();
                pageViewModel = await _iPageManager.GetPageByUrlAsync(name);
                if (pageViewModel != null)
                {
                    if (!string.IsNullOrEmpty(pageViewModel.MetaTitle))
                    {
                        ViewData["Title"] = pageViewModel.MetaTitle;
                    }
                    if (!string.IsNullOrEmpty(pageViewModel.MetaKeyword))
                    {
                        ViewData["Keywords"] = pageViewModel.MetaKeyword;
                    }
                    if (!string.IsNullOrEmpty(pageViewModel.MetaDescription))
                    {
                        ViewData["Description"] = pageViewModel.MetaDescription;
                    }
                    return View("Index", pageViewModel);
                }
                else
                {
                    return ErrorNullView();
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<IActionResult> MyBlog(string name)
        {
            try
            {
                BlogViewModel blogViewModel = new BlogViewModel();

                blogViewModel = await _iBlogManager.GetBlogByUrlAsync(name);

                if (blogViewModel != null)
                {
                    //if (blog.PrimaryImageId != null && blog.PrimaryImageId.HasValue)
                    //{
                    //    var mediaViewModel = await _iMediaManager.GetMediaByIdAsync(blog.PrimaryImageId.Value, _iWebHostEnvironment.WebRootPath);
                    //    blog.PrimaryImageUrl = "/" + mediaViewModel.Url;
                    //}
                    //else
                    //{
                    //    blog.PrimaryImageUrl = "/default/images/default-addphoto-image.jpg";
                    //}
                    //blog.PrimaryImageUrl = blog.PrimaryImageId != null ? "/" + context.Media.Where(x => x.Id == blog.PrimaryImageId).Select(x => x.Url).FirstOrDefault() : "/default/images/default-addphoto-image.jpg";

                    var blogCategoryViewModel = await _iBlogCategoryManager.GetBlogCategorysAsync();
                    blogCategoryViewModel = blogCategoryViewModel.Where(t => t.Status == true).ToList().Take(5);

                    var blogs = await _iBlogManager.GetBlogsAsync();
                    blogs = blogs.Where(t => t.Status == true).OrderBy(m => m.AddedOn).ToList();

                    foreach (var blogCategroy in blogCategoryViewModel)
                    {
                        blogCategroy.totalBlogs = blogs.Where(m => m.Status == true && m.CategoryId == blogCategroy.Id).Count();
                    }

                    ViewBag.Blogs = blogs.Take(5);
                    ViewBag.BlogCategory = blogCategoryViewModel;

                    return View(blogViewModel);
                }
                else
                {
                    return ErrorNullView();
                }

            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<IActionResult> MyBlogCategoryList(int id, string url)
        {
            try
            {
                BlogList list = new BlogList();

                BlogCategoryViewModel blogCategory = new BlogCategoryViewModel();

                blogCategory = await _iBlogCategoryManager.GetBlogCategoryByUrlAsync(url);

                list = await GetBlog(id, null, 1, blogCategory.Id);

                ViewData["Title"] = blogCategory.Name;
                ViewData["Keywords"] = null;
                ViewData["Description"] = "Welcome to My Blogs";

                ViewBag.url = url;

                return View("MyBlogList", list);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<IActionResult> MyBlogList(int id)
        {
            try
            {
                BlogList list = new BlogList();
                list = await GetBlog(1, null, 1, id);

                var blogCategoryViewModel = await _iBlogCategoryManager.GetBlogCategorysAsync();
                blogCategoryViewModel = blogCategoryViewModel.Where(t => t.Status == true).ToList().Take(5);

                var blogs = await _iBlogManager.GetBlogsAsync();
                blogs = blogs.Where(t => t.Status == true).OrderBy(m => m.AddedOn).ToList();

                foreach (var blogCategroy in blogCategoryViewModel)
                {
                    blogCategroy.totalBlogs = blogs.Where(m => m.Status == true && m.CategoryId == blogCategroy.Id).Count();
                }

                ViewBag.Blogs = blogs.Take(5);
                ViewBag.BlogCategory = blogCategoryViewModel;

                ViewData["Title"] = "My blogs";
                ViewData["Keywords"] = null;
                ViewData["Description"] = "Welcome to My Blogs";

                return View("MyBlogList", list);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<BlogList> GetBlog(int? page, string searchText, int? status, int blogCategoryId)
        {
            BlogList bList = new BlogList();
            try
            {
                int pageSize = 5;
                int pageNo = page == null ? 1 : Convert.ToInt32(page);

                var skip = pageSize * (Convert.ToInt32(pageNo) - 1);

                
                var blogViewModels = await _iBlogManager.GetBlogsAsync();
                var blogs = _iMapper.Map<IEnumerable<BlogViewModel>, IEnumerable<Blog>>(blogViewModels);
                var result = blogs.Where(x => x.Status == (status == null ? x.Status : (status == 1 ? true : false)) && x.Name.Contains(searchText == null ? x.Name : searchText) && (blogCategoryId == 0 || x.CategoryId == blogCategoryId)).OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToList();

                //foreach (var u in result)
                //{
                //    if (u.PrimaryImageId != null && u.PrimaryImageId.HasValue)
                //    {
                //        var mediaViewModel = await _iMediaManager.GetMediaByIdAsync(u.PrimaryImageId.Value, _iWebHostEnvironment.WebRootPath);
                //        u.PrimaryImageUrl = "/" + mediaViewModel.Url;
                //    }
                //    else
                //    {
                //        u.PrimaryImageUrl = "/default/images/default-addphoto-image.jpg";
                //    }
                //}

                //result.ForEach(u => u.PrimaryImageUrl = u.PrimaryImageId != null ? "/" + context.Media.Where(x => x.Id == u.PrimaryImageId).Select(x => x.Url).FirstOrDefault() : "/default/images/default-addphoto-image.jpg");

                int total = blogs.Where(x => x.Status == (status == null ? x.Status : (status == 1 ? true : false)) && x.Name.Contains(searchText == null ? x.Name : searchText) && (blogCategoryId == 0 || x.CategoryId == blogCategoryId)).Count();

                PagingInfo pagingInfo = new PagingInfo();
                pagingInfo.CurrentPage = pageNo;
                pagingInfo.TotalItems = total;
                pagingInfo.ItemsPerPage = pageSize;

                bList.blog = result;
                bList.allTotal = blogs.Count();
                bList.activeTotal = blogs.Where(x => x.Status == true).Count();
                bList.inactiveTotal = blogs.Where(x => x.Status == false).Count();
                bList.searchText = searchText;
                bList.status = null;
                bList.pagingInfo = pagingInfo;
                
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetBlog"));
            }

            return bList;
        }

        [Route("/robots.txt")]
        public string RobotsTxt()
        {
            var sb = new StringBuilder();
            sb.AppendLine("User-agent: *")
                .AppendLine("Disallow:")
                .Append("sitemap: ")
                .Append(this.Request.Scheme)
                .Append("://")
                .Append(this.Request.Host)
                .AppendLine("/sitemap.xml");

            return sb.ToString();
        }

        #endregion
    }
}