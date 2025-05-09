using API.Models;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PersistentHistoryService
    {
        private readonly AppDbContext _context;

        public PersistentHistoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(string catFact, string query, string gifUrl)
        {
            var item = new SearchHistoryEntity
            {
                Timestamp = DateTime.UtcNow,
                CatFact = catFact,
                Query = query,
                GifUrl = gifUrl
            };

            _context.SearchHistories.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SearchHistoryEntity>> GetAllAsync()
        {
            return await _context.SearchHistories
                .OrderByDescending(h => h.Timestamp) // ordena por fecha
                .ToListAsync();
        }

    }

}
