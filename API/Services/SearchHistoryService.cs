using API.Models;

namespace API.Services
{
    public class SearchHistoryService
    {
        private readonly List<SearchHistoryItem> _history = new();

        public void Add(SearchHistoryItem item)
        {
            _history.Add(item);
        }

        public List<SearchHistoryItem> GetAll()
        {
            return _history;
        }
    }
}
