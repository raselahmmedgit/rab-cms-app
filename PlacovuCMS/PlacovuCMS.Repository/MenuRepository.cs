using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private AppDbContext _context;
        public MenuRepository()
        {
            _context = new AppDbContext();
        }
        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Menu> GetMenuAsync(int id)
        {
            return await _context.Menu.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Menu>> GetMenusAsync()
        {
            return await _context.Menu.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Menu>> GetMenusAsync(int pageSize, int skip, string searchText, int? status)
        {
            try
            {
                return await _context.Menu.Where(x => x.Status == (status == null ? x.Status : (status == 1 ? true : false)) && x.Name.Contains(searchText == null ? x.Name : searchText)).OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetTotalMenusAsync()
        {
            try
            {
                return await _context.Menu.AsNoTracking().CountAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetTotalMenusAsync(string searchText, int? status)
        {
            try
            {
                return await _context.Menu.Where(x => x.Status == (status == null ? x.Status : (status == 1 ? true : false)) && x.Name.Contains(searchText == null ? x.Name : searchText)).CountAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetTotalActiveMenusAsync()
        {
            try
            {
                return await _context.Menu.Where(x => x.Status == true).CountAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetTotalInactiveMenusAsync()
        {
            try
            {
                return await _context.Menu.Where(x => x.Status == false).CountAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<int> InsertOrUpdatetMenuAsync(Menu model)
        {
            int result = 0;
            using (AppDbContext context = new AppDbContext())
            {
                if (model.Id == 0)
                {
                   await context.Menu.AddAsync(model);
                }
                else
                {
                    context.Menu.Update(model);
                }
                result = await context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> InsertMenuAsync(Menu model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.Menu.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateMenuAsync(Menu model)
        {
            if (model.Id > 0)
            {
                _context.Menu.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteMenuAsync(Menu model)
        {
            if (model.Id > 0)
            {
                _context.Menu.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }
    }

    public interface IMenuRepository
    {
        Task<Menu> GetMenuAsync(int id);
        Task<IEnumerable<Menu>> GetMenusAsync();
        Task<IEnumerable<Menu>> GetMenusAsync(int pageSize, int skip, string searchText, int? status);
        Task<int> GetTotalMenusAsync();
        Task<int> GetTotalMenusAsync(string searchText, int? status);
        Task<int> GetTotalActiveMenusAsync();
        Task<int> GetTotalInactiveMenusAsync();
        Task<int> InsertOrUpdatetMenuAsync(Menu model);
        Task<int> InsertMenuAsync(Menu model);
        Task<int> UpdateMenuAsync(Menu model);
        Task<int> DeleteMenuAsync(Menu model);
    }
}
