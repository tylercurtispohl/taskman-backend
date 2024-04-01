namespace taskman_backend.Dtos.CardList
{
    public class CreateCardListDto
    {
        public string Name { get; set; } = string.Empty;

        public long BoardId { get; set; }
    }
}
