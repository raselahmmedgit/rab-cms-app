using Microsoft.AspNetCore.Http;
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
    public class MediaRepository : IMediaRepository
    {
        private AppDbContext _context;
        public MediaRepository()
        {
            _context = new AppDbContext();
        }
        public MediaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Media> GetMediaAsync(int id)
        {
            return await _context.Media.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Media> GetMediaByPrimaryImageId(int id)
        {
            try
            {
                Media media = null;
                using (var context = new AppDbContext())
                {
                    media = await context.Media.FirstOrDefaultAsync(x => x.Id == id);
                }
                return media;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Media>> GetMediasAsync()
        {
            return await _context.Media.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Media>> GetMediaById(int id)
        {
            try
            {
                var resultList = await _context.Media.Where(x => x.Id == id).ToListAsync();
                return resultList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateMediaAsync(MediaViewModel mediaViewModel)
        {
            try
            {
                var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@Id",
                                SqlDbType =  System.Data.SqlDbType.Int,
                                Direction = System.Data.ParameterDirection.Input,
                                Value = mediaViewModel.Id
                            },
                            new SqlParameter() {
                                ParameterName = "@Name",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 100,
                                Value = mediaViewModel.Name
                            },
                            new SqlParameter() {
                                ParameterName = "@Url",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 250,
                                Value = mediaViewModel.Url
                            },
                            new SqlParameter() {
                                ParameterName = "@Title",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 100,
                                Value = mediaViewModel.Title??(object)DBNull.Value
                            },
                            new SqlParameter() {
                                ParameterName = "@Alt",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 100,
                                Value = mediaViewModel.Alt??(object)DBNull.Value
                            },
                            new SqlParameter() {
                                ParameterName = "@Description",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 100,
                                Value = mediaViewModel.Description??(object)DBNull.Value
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@Result",
                                SqlDbType = System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Output,
                                Size = 50
                            }};

                await _context.Database.ExecuteSqlRawAsync("[dbo].[sp_UpdateMedia] @Id, @Name, @Url, @Title, @Alt, @Description, @Result out", param);

                return Convert.ToString(param[6].Value);
              
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> InsertOrUpdatetMediaAsync(Media model)
        {
            if (model.Id == 0)
            {
                await _context.Media.AddAsync(model);
            }
            else
            {
                _context.Media.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<string[]> InsertMediaAsync(IFormFile file, string fileName, int? parentId)
        {
            try
            {
                var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@Name",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size=100,
                                Value = fileName == null ? file.FileName : fileName
                            },
                            new SqlParameter() {
                                ParameterName = "@Url",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size=250,
                                Value = ImageHelper.GetPath() + (fileName == null ? file.FileName : fileName)
                            },
                            new SqlParameter() {
                                ParameterName = "@Title",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 100,
                                Value = DBNull.Value
                            },
                            new SqlParameter() {
                                ParameterName = "@Alt",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 100,
                                Value = DBNull.Value
                            },
                            new SqlParameter() {
                                ParameterName = "@Description",
                                SqlDbType =  System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Input,
                                Size = 100,
                                Value = DBNull.Value
                            },
                            new SqlParameter() {
                                ParameterName = "@ParentId",
                                SqlDbType =  System.Data.SqlDbType.Int,
                                Direction = System.Data.ParameterDirection.Input,
                                Value = parentId ?? (object)DBNull.Value
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@Result",
                                SqlDbType = System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Output,
                                Size = 50
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@CreatedFileName",
                                SqlDbType = System.Data.SqlDbType.VarChar,
                                Direction = System.Data.ParameterDirection.Output,
                                Size = 100
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@CreatedId",
                                SqlDbType = System.Data.SqlDbType.Int,
                                Direction = System.Data.ParameterDirection.Output
                            }};
                await _context.Database.ExecuteSqlRawAsync("[dbo].[sp_InsertMedia] @Name, @Url, @Title, @Alt, @Description, @ParentId, @Result out, @CreatedFileName out, @CreatedId out", param);
                return new string[] { Convert.ToString(param[6].Value), Convert.ToString(param[7].Value), Convert.ToString(param[8].Value) };

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteMediaAsync(string ids)
        {
            try
            {
                var param = new SqlParameter[] {
                                    new SqlParameter() {
                                        ParameterName = "@Id",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Size=50,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = ids
                                    }};
                await _context.Database.ExecuteSqlRawAsync("[dbo].[sp_DeleteMedia] @Id", param);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteMediaAsync(Media model)
        {
            if (model.Id > 0)
            {
                _context.Media.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }

    }

    public interface IMediaRepository
    {
        Task<Media> GetMediaAsync(int id);
        Task<Media> GetMediaByPrimaryImageId(int id);
        Task<IEnumerable<Media>> GetMediaById(int id);
        Task<IEnumerable<Media>> GetMediasAsync();
        Task<int> InsertOrUpdatetMediaAsync(Media model);
        Task<string[]> InsertMediaAsync(IFormFile file, string fileName, int? parentId);
        Task<string> UpdateMediaAsync(MediaViewModel model);
        Task DeleteMediaAsync(string ids);
        Task<int> DeleteMediaAsync(Media model);
    }
}
