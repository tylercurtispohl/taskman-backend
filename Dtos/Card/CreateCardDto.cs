namespace taskman_backend.Dtos.Card
{
    public class CreateCardDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public long CardListId { get; set; }
    }
}
