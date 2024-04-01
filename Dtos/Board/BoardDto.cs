using taskman_backend.Dtos.CardList;

namespace taskman_backend.Dtos.Board
{
    public class BoardDto
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string Name { get; set; } = string.Empty;

        public List<CardListDto> CardLists { get; set; } = new List<CardListDto>();
    }
}
