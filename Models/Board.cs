using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taskman_backend.Models
{
    public class Board
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string Name { get; set; } = string.Empty;

        public List<CardList> CardLists { get; set; } = new List<CardList>();
    }
}
