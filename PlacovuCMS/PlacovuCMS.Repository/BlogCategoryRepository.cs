using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private AppDbContext _context;
        public BlogCategoryRepository()
        {
            _context = new AppDbContext();
        }
        public BlogCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BlogCategoryList> GetBlogCategoryList(int? page, string searchText, int? status)
        {
            int pageSize = 3;
            int pageNo = page == null ? 1 : Convert.ToInt32(page);
            var param = new SqlParameter[] {
                                    new SqlParameter() {
                                        ParameterName = "@PageNo",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = pageNo
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Name",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size = 100,
                                        Value =  searchText ?? (object)DBNull.Value
        },
                                    new SqlParameter() {
                                        ParameterName = "@PageSize",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = pageSize
                                    },
                                    new SqlParameter()
                                    {
                                        ParameterName = "@Status",
                                        SqlDbType = System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value=status ?? (object)DBNull.Value
                                    }
                };
            //var student3 = context.BlogCategory.FromSql("[dbo].[sp_GetBlogCategoryWithPaging] @PageNo, @Name, @PageSize, @Status", param);

            BlogCategoryList bcList = new BlogCategoryList();
            using (var cnn = _context.Database.GetDbConnection())
            {
                var cmm = cnn.CreateCommand();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "[dbo].[sp_GetBlogCategoryWithPaging]";
                cmm.Parameters.AddRange(param);
                cmm.Connection = cnn;
                cnn.Open();
                var reader = await cmm.ExecuteReaderAsync();

                List<BlogCategory> list = new List<BlogCategory>();
                PagingInfo pagingInfo = new PagingInfo();
                //while (reader.HasRows)
                //{
                while (reader.Read())
                {
                    BlogCategory blogCategory = new BlogCategory();
                    blogCategory.Id = Convert.ToInt32(reader["Id"]);
                    blogCategory.ParentId = reader["ParentId"] == DBNull.Value ? null : (Int32?)Convert.ToInt32(reader["ParentId"]);
                    blogCategory.Name = Convert.ToString(reader["Name"]);
                    blogCategory.Url = Convert.ToString(reader["Url"]);
                    blogCategory.MetaTitle = Convert.ToString(reader["MetaTitle"]);
                    blogCategory.MetaKeyword = Convert.ToString(reader["MetaKeyword"]);
                    blogCategory.MetaDescription = Convert.ToString(reader["MetaDescription"]);
                    blogCategory.Description = Convert.ToString(reader["Description"]);
                    blogCategory.AddedOn = Convert.ToDateTime(reader["AddedOn"]);
                    blogCategory.Status = Convert.ToBoolean(reader["Status"]);
                    list.Add(blogCategory);
                }
                reader.NextResult();
                while (reader.Read())
                {
                    pagingInfo.CurrentPage = pageNo;
                    pagingInfo.TotalItems = Convert.ToInt32(reader["Total"]);
                    pagingInfo.ItemsPerPage = pageSize;

                    bcList.blogCategory = list;
                    bcList.allTotal = Convert.ToInt32(reader["AllTotalPage"]);
                    bcList.activeTotal = Convert.ToInt32(reader["ActiveTotalPage"]);
                    bcList.inactiveTotal = Convert.ToInt32(reader["InActiveTotalPage"]);
                    bcList.searchText = searchText;
                    bcList.status = status;
                    bcList.pagingInfo = pagingInfo;
                }
                //}
            }
            return bcList;
        }
        public async Task<BlogCategory> GetBlogCategoryAsync(int id)
        {
            try
            {
                return await _context.BlogCategory.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<BlogCategory> GetBlogCategoryByUrlAsync(string url)
        {
            try
            {
                return await _context.BlogCategory.AsNoTracking().SingleOrDefaultAsync(x => x.Url == url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BlogCategory>> GetBlogCategorysAsync()
        {
            return await _context.BlogCategory.AsNoTracking().ToListAsync();
        }

        public async Task<int> InsertOrUpdatetBlogCategoryAsync(BlogCategory model)
        {
            try
            {
                int result = 0;
                using (AppDbContext context = new AppDbContext())
                {
                    if (model.Id == 0)
                    {
                       await context.BlogCategory.AddAsync(model);
                    }
                    else
                    {
                        context.BlogCategory.Update(model);
                    }
                    result =  await context.SaveChangesAsync();
                }
                return result;
                
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertBlogCategoryAsync(BlogCategory model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.BlogCategory.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateBlogCategoryAsync(BlogCategory model)
        {
            if (model.Id > 0)
            {
                _context.BlogCategory.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBlogCategoryAsync(BlogCategory model)
        {
            if (model.Id > 0)
            {
                _context.BlogCategory.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<List<SelectListItem>> GetActiveCategory()
        {
            try
            {
                List<SelectListItem> activeBlogCategory = new List<SelectListItem>();
                activeBlogCategory = await _context.BlogCategory.Where(x => x.Status == true).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToListAsync();
                return activeBlogCategory;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }

    public interface IBlogCategoryRepository
    {
        Task<BlogCategoryList> GetBlogCategoryList(int? page, string searchText, int? status);
        Task<BlogCategory> GetBlogCategoryAsync(int id);
        Task<BlogCategory> GetBlogCategoryByUrlAsync(string url);
        Task<IEnumerable<BlogCategory>> GetBlogCategorysAsync();
        Task<int> InsertOrUpdatetBlogCategoryAsync(BlogCategory model);
        Task<int> InsertBlogCategoryAsync(BlogCategory model);
        Task<int> UpdateBlogCategoryAsync(BlogCategory model);
        Task<int> DeleteBlogCategoryAsync(BlogCategory model);
        Task<List<SelectListItem>> GetActiveCategory();
    }
}
