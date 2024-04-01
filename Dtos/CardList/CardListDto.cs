using taskman_backend.Dtos.Board;
using taskman_backend.Dtos.Card;

namespace taskman_backend.Dtos.CardList
{
    public class CardListDto
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public long? BoardId { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<CardDto> Cards { get; set; } = new List<CardDto>();
    }
}
