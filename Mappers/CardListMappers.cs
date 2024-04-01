using Microsoft.IdentityModel.Protocols;
using taskman_backend.Dtos.CardList;
using taskman_backend.Models;

namespace taskman_backend.Mappers
{
    public static class CardListMappers
    {
        public static CardListDto ToCardListDto(this CardList cardList)
        {
            return new CardListDto
            {
                Id = cardList.Id,
                CreatedAt = cardList.CreatedAt,
                UpdatedAt = cardList.UpdatedAt,
                BoardId = cardList.BoardId,
                Name = cardList.Name,
                Cards = cardList.Cards.Select(c => c.ToCardDto()).ToList()
            };
        }

        public static CardList ToCardListFromCreateCardListDto(this CreateCardListDto createCardListDto)
        {
            return new CardList
            {
                Name = createCardListDto.Name,
                BoardId = createCardListDto.BoardId,
            };
        }
    }
}
