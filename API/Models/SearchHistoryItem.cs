namespace API.Models
{
    public class SearchHistoryItem
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string CatFact { get; set; } = string.Empty;
        public string Query { get; set; } = string.Empty;

        public string GifUrl { get; set; } = string.Empty;
    }
}
