using System.Runtime.CompilerServices;
using taskman_backend.Dtos.Card;
using taskman_backend.Models;

namespace taskman_backend.Mappers
{
    public static class CardMappers
    {
        public static CardDto ToCardDto(this Card card)
        {
            return new CardDto
            {
                Id = card.Id,
                Name = card.Name,
                UpdatedAt = card.UpdatedAt,
                CreatedAt = card.CreatedAt,
                Description = card.Description,
                CardListId = card.CardListId,
            };
        }

        public static Card ToCardFromCreateCardDto(this CreateCardDto createCardDto)
        {
            return new Card
            {
                Name = createCardDto.Name,
                Description = createCardDto.Description,
                CardListId = createCardDto.CardListId,
            };
        }
    }
}
