using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class EmailSmsConfigRepository : IEmailSmsConfigRepository
    {
        private AppDbContext _context;
        public EmailSmsConfigRepository()
        {
            _context = new AppDbContext();
        }
        public EmailSmsConfigRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmailSmsConfig> GetEmailSmsConfigAsync(int id)
        {
            return await _context.EmailSmsConfig.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmailSmsConfig> GetEmailSmsConfigFirstOrDefaultAsync()
        {
            return await _context.EmailSmsConfig.FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<EmailSmsConfig>> GetEmailSmsConfigsAsync()
        {
            return await _context.EmailSmsConfig.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetEmailSmsConfigAsync(EmailSmsConfig model)
        {
            if (model.Id == 0)
            {
                await _context.EmailSmsConfig.AddAsync(model);
            }
            else
            {
                _context.EmailSmsConfig.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertEmailSmsConfigAsync(EmailSmsConfig model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.EmailSmsConfig.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateEmailSmsConfigAsync(EmailSmsConfig model)
        {
            if (model.Id > 0)
            {
                _context.EmailSmsConfig.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmailSmsConfigAsync(EmailSmsConfig model)
        {
            if (model.Id > 0)
            {
                _context.EmailSmsConfig.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }
    }

    public interface IEmailSmsConfigRepository
    {
        Task<EmailSmsConfig> GetEmailSmsConfigAsync(int id);
        Task<EmailSmsConfig> GetEmailSmsConfigFirstOrDefaultAsync();
        Task<IEnumerable<EmailSmsConfig>> GetEmailSmsConfigsAsync();
        Task<int> InsertOrUpdatetEmailSmsConfigAsync(EmailSmsConfig model);
        Task<int> InsertEmailSmsConfigAsync(EmailSmsConfig model);
        Task<int> UpdateEmailSmsConfigAsync(EmailSmsConfig model);
        Task<int> DeleteEmailSmsConfigAsync(EmailSmsConfig model);
    }
}
