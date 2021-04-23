using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class ContactUsConfigRepository : IContactUsConfigRepository
    {
        private AppDbContext _context;
        public ContactUsConfigRepository()
        {
            _context = new AppDbContext();
        }
        public ContactUsConfigRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContactUsConfig> GetContactUsConfigAsync(int id)
        {
            return await _context.ContactUsConfig.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContactUsConfig> GetContactUsConfigFirstOrDefaultAsync()
        {
            return await _context.ContactUsConfig.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ContactUsConfig>> GetContactUsConfigsAsync()
        {
            return await _context.ContactUsConfig.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetContactUsConfigAsync(ContactUsConfig model)
        {
            if (model.Id == 0)
            {
                await _context.ContactUsConfig.AddAsync(model);
            }
            else
            {
                _context.ContactUsConfig.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertContactUsConfigAsync(ContactUsConfig model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.ContactUsConfig.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateContactUsConfigAsync(ContactUsConfig model)
        {
            if (model.Id > 0)
            {
                _context.ContactUsConfig.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteContactUsConfigAsync(ContactUsConfig model)
        {
            if (model.Id > 0)
            {
                _context.ContactUsConfig.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }
    }

    public interface IContactUsConfigRepository
    {
        Task<ContactUsConfig> GetContactUsConfigAsync(int id);
        Task<ContactUsConfig> GetContactUsConfigFirstOrDefaultAsync();
        Task<IEnumerable<ContactUsConfig>> GetContactUsConfigsAsync();
        Task<int> InsertOrUpdatetContactUsConfigAsync(ContactUsConfig model);
        Task<int> InsertContactUsConfigAsync(ContactUsConfig model);
        Task<int> UpdateContactUsConfigAsync(ContactUsConfig model);
        Task<int> DeleteContactUsConfigAsync(ContactUsConfig model);
    }
}
