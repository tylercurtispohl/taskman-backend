using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace taskman_backend.Models
{
    public class CardList
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public long? BoardId { get; set; }

        public Board? board { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Card> Cards { get; set;} = new List<Card>();
    }
}
