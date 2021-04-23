using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class EmailSmsHistoryRepository : IEmailSmsHistoryRepository
    {
        private AppDbContext _context;
        public EmailSmsHistoryRepository()
        {
            _context = new AppDbContext();
        }
        public EmailSmsHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmailSmsHistory> GetEmailSmsHistoryAsync(int id)
        {
            return await _context.EmailSmsHistory.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<EmailSmsHistory>> GetEmailSmsHistorysAsync()
        {
            return await _context.EmailSmsHistory.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetEmailSmsHistoryAsync(EmailSmsHistory model)
        {
            if (model.Id == 0)
            {
                await _context.EmailSmsHistory.AddAsync(model);
            }
            else
            {
                _context.EmailSmsHistory.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertEmailSmsHistoryAsync(EmailSmsHistory model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.EmailSmsHistory.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateEmailSmsHistoryAsync(EmailSmsHistory model)
        {
            if (model.Id > 0)
            {
                _context.EmailSmsHistory.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmailSmsHistoryAsync(EmailSmsHistory model)
        {
            if (model.Id > 0)
            {
                _context.EmailSmsHistory.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }
    }

    public interface IEmailSmsHistoryRepository
    {
        Task<EmailSmsHistory> GetEmailSmsHistoryAsync(int id);
        Task<IEnumerable<EmailSmsHistory>> GetEmailSmsHistorysAsync();
        Task<int> InsertOrUpdatetEmailSmsHistoryAsync(EmailSmsHistory model);
        Task<int> InsertEmailSmsHistoryAsync(EmailSmsHistory model);
        Task<int> UpdateEmailSmsHistoryAsync(EmailSmsHistory model);
        Task<int> DeleteEmailSmsHistoryAsync(EmailSmsHistory model);
    }
}
