using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class SiteInfoRepository : ISiteInfoRepository
    {
        private AppDbContext _context;
        public SiteInfoRepository()
        {
            _context = new AppDbContext();
        }
        public SiteInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SiteInfo> GetSiteInfoAsync(int id)
        {
            return await _context.SiteInfo.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SiteInfo>> GetSiteInfosAsync()
        {
            return await _context.SiteInfo.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetSiteInfoAsync(SiteInfo model)
        {
            if (model.Id == 0)
            {
                await _context.SiteInfo.AddAsync(model);
            }
            else
            {
                _context.SiteInfo.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertSiteInfoAsync(SiteInfo model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.SiteInfo.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateSiteInfoAsync(SiteInfo model)
        {
            if (model.Id > 0)
            {
                _context.SiteInfo.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSiteInfoAsync(SiteInfo model)
        {
            if (model.Id > 0)
            {
                _context.SiteInfo.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }

    }

    public interface ISiteInfoRepository
    {
        Task<SiteInfo> GetSiteInfoAsync(int id);
        Task<IEnumerable<SiteInfo>> GetSiteInfosAsync();
        Task<int> InsertOrUpdatetSiteInfoAsync(SiteInfo model);
        Task<int> InsertSiteInfoAsync(SiteInfo model);
        Task<int> UpdateSiteInfoAsync(SiteInfo model);
        Task<int> DeleteSiteInfoAsync(SiteInfo model);
    }
}
