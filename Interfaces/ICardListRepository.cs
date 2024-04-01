using taskman_backend.Dtos.Board;
using taskman_backend.Dtos.CardList;
using taskman_backend.Helpers;
using taskman_backend.Models;

namespace taskman_backend.Interfaces
{
    public interface ICardListRepository
    {
        Task<List<CardList>> GetAll(CardListQueryObject queryObject);
        Task<CardList> GetById(long id);
        Task<CardList> Create(CardList cardList);
        Task<CardList?> Update(long id, UpdateCardListDto updateCardListDto);
        Task<CardList?> Delete(long id);
        Task<bool> CardListExists(long id);
    }
}
