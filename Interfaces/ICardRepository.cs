using taskman_backend.Dtos.Board;
using taskman_backend.Dtos.Card;
using taskman_backend.Models;

namespace taskman_backend.Interfaces
{
    public interface ICardRepository
    {
        Task<List<Card>> GetAll();
        Task<Card> GetById(long id);
        Task<Card> Create(Card card);
        Task<Card?> Update(long id, UpdateCardDto updateCardDto);
        Task<Card?> Delete(long id);
    }
}
