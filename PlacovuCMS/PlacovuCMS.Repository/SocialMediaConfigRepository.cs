using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class SocialMediaConfigRepository : ISocialMediaConfigRepository
    {
        private AppDbContext _context;
        public SocialMediaConfigRepository()
        {
            _context = new AppDbContext();
        }
        public SocialMediaConfigRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SocialMediaConfig> GetSocialMediaConfigAsync(int id)
        {
            return await _context.SocialMediaConfig.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SocialMediaConfig>> GetSocialMediaConfigsAsync()
        {
            return await _context.SocialMediaConfig.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetSocialMediaConfigAsync(SocialMediaConfig model)
        {
            if (model.Id == 0)
            {
                await _context.SocialMediaConfig.AddAsync(model);
            }
            else
            {
                _context.SocialMediaConfig.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertSocialMediaConfigAsync(SocialMediaConfig model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.SocialMediaConfig.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateSocialMediaConfigAsync(SocialMediaConfig model)
        {
            if (model.Id > 0)
            {
                _context.SocialMediaConfig.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSocialMediaConfigAsync(SocialMediaConfig model)
        {
            if (model.Id > 0)
            {
                _context.SocialMediaConfig.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }
    }

    public interface ISocialMediaConfigRepository
    {
        Task<SocialMediaConfig> GetSocialMediaConfigAsync(int id);
        Task<IEnumerable<SocialMediaConfig>> GetSocialMediaConfigsAsync();
        Task<int> InsertOrUpdatetSocialMediaConfigAsync(SocialMediaConfig model);
        Task<int> InsertSocialMediaConfigAsync(SocialMediaConfig model);
        Task<int> UpdateSocialMediaConfigAsync(SocialMediaConfig model);
        Task<int> DeleteSocialMediaConfigAsync(SocialMediaConfig model);
    }
}
