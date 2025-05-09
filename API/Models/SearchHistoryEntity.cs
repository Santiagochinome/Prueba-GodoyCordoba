using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class SearchHistoryEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string CatFact { get; set; } = string.Empty;

        public string Query { get; set; } = string.Empty;

        public string GifUrl { get; set; } = string.Empty;
    }
}
