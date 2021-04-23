using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class CommonSpAccessRepository : ICommonSpAccessRepository
    {
        private AppDbContext _context;
        public CommonSpAccessRepository()
        {
            _context = new AppDbContext();
        }
        public CommonSpAccessRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> GetUrl(int? id, string url)
        {
            try
            {
                var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@Url",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 100,
                                Value = url
                            },
                            new SqlParameter() {
                                ParameterName = "@Sep",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 1,
                                Value = "-"
                            },
                            new SqlParameter() {
                                ParameterName = "@TableName",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 25,
                                Value = DBNull.Value
                            },
                                new SqlParameter() {
                                ParameterName = "@Id",
                                SqlDbType =  System.Data.SqlDbType.Int,
                                Direction = System.Data.ParameterDirection.Input,
                                Value = id == null ? DBNull.Value : id
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@TempUrl",
                                SqlDbType = System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Output,
                                Size = 100
                            }};

                using (var cntx = new AppDbContext())
                {
                    await cntx.Database.ExecuteSqlRawAsync("[dbo].[sp_GetURL] @Url, @Sep, @TableName, @Id, @TempUrl out", param);
                }

                return Convert.ToString(param[4].Value);
                
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<List<SelectListItem>> GetMediaDate()
        {
            List<SelectListItem> mediaDateList = new List<SelectListItem>();
            List<MediaDate> mdList = new List<MediaDate>();
            /*Does not work https://docs.microsoft.com/en-us/ef/core/querying/raw-sql
            DbSet<MediaDate> set = context.Set<MediaDate>();
            mediaDateList = set.FromSql("[dbo].[sp_GetMediaDate]").Select(x => new SelectListItem { Text = x.DateText, Value = x.DateValue }).ToList();
            */

            using (var cnn = _context.Database.GetDbConnection())
            {
                var cmm = cnn.CreateCommand();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "[dbo].[sp_GetMediaDate]";
                cmm.Connection = cnn;
                cnn.Open();
                var reader = await cmm.ExecuteReaderAsync();

                while (reader.Read())
                {
                    MediaDate mediaDate = new MediaDate();
                    mediaDate.DateText = Convert.ToString(reader["DateText"]);
                    mediaDate.DateValue = Convert.ToString(reader["DateValue"]);
                    mdList.Add(mediaDate);
                }
            }

            mediaDateList = mdList.Select(x => new SelectListItem { Text = x.DateText, Value = x.DateValue }).ToList();
            return mediaDateList;
        }

        public async Task<List<Media>> GetMediaWithPaging(string date, int page, string name)
        {
            //http://webdeveloperplus.com/jquery/create-a-dynamic-scrolling-content-box-using-ajax/ http://stackoverflow.com/questions/8480466/how-to-check-if-scrollbar-is-at-the-bottom
            //http://stackoverflow.com/questions/19933115/mvc-4-postback-on-dropdownlist-change
            var param = new SqlParameter[] {
                                    new SqlParameter() {
                                        ParameterName = "@PageNo",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = page
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@PageSize",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = "35"
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Name",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size = 100,
                                        Value = name ?? (object)DBNull.Value
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@FileType",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size = 10,
                                        Value = "image"
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@MediaDateSearch",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size = 10,
                                        Value =  date == "null" ? "all" : date
                                    }};
            var mediaList =   await _context.Media.FromSqlRaw("[dbo].[sp_GetMediaWithPaging] @PageNo, @PageSize, @Name, @FileType, @MediaDateSearch", param).ToListAsync();
            return mediaList;
        }

        public async Task<List<Media>> GetMediaWithPaging(string fileType, string date, int page, string name)
        {
            //http://webdeveloperplus.com/jquery/create-a-dynamic-scrolling-content-box-using-ajax/ http://stackoverflow.com/questions/8480466/how-to-check-if-scrollbar-is-at-the-bottom
            //http://stackoverflow.com/questions/19933115/mvc-4-postback-on-dropdownlist-change

            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = page
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = 35
                        },
                        new SqlParameter() {
                            ParameterName = "@Name",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Size = 100,
                            Value = name ?? (object)DBNull.Value
                        },
                            new SqlParameter() {
                            ParameterName = "@FileType",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Size = 10,
                            Value = fileType
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@MediaDateSearch",
                            SqlDbType = System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Size = 10,
                            Value = date=="null" ? "all" : date
                        }};
            var result = await _context.Media.FromSqlRaw("[dbo].[sp_GetMediaWithPaging] @PageNo, @PageSize, @Name, @FileType, @MediaDateSearch", param).ToListAsync();

            return result;

        }

        public async Task<List<Media>> GetMediaWithPagingForBlog(string date, int page, string name)
        {
            //http://webdeveloperplus.com/jquery/create-a-dynamic-scrolling-content-box-using-ajax/ http://stackoverflow.com/questions/8480466/how-to-check-if-scrollbar-is-at-the-bottom
            //http://stackoverflow.com/questions/19933115/mvc-4-postback-on-dropdownlist-change
            
            var context = new AppDbContext();
            var param = new SqlParameter[] {
                                    new SqlParameter() {
                                        ParameterName = "@PageNo",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = page
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@PageSize",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = "35"
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Name",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size = 100,
                                        Value = name ?? (object)DBNull.Value
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@FileType",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size = 10,
                                        Value = "image"
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@MediaDateSearch",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size = 10,
                                        Value =  date == "null" ? "all" : date
                                    }};
            var mediaList = await context.Media.FromSqlRaw("[dbo].[sp_GetMediaWithPaging] @PageNo, @PageSize, @Name, @FileType, @MediaDateSearch", param).ToListAsync();
            return mediaList;
        }
    }
    public interface ICommonSpAccessRepository
    {
        Task<string> GetUrl(int? id, string url);
        Task<List<SelectListItem>> GetMediaDate();
        Task<List<Media>> GetMediaWithPaging(string date, int page, string name);
        Task<List<Media>> GetMediaWithPaging(string fileType, string date, int page, string name);
        Task<List<Media>> GetMediaWithPagingForBlog(string date, int page, string name);
    }
}
