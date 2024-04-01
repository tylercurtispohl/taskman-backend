using Microsoft.EntityFrameworkCore;
using taskman_backend.Data;
using taskman_backend.Dtos.CardList;
using taskman_backend.Helpers;
using taskman_backend.Interfaces;
using taskman_backend.Models;

namespace taskman_backend.Repositories
{
    public class CardListRepository : ICardListRepository
    {
        private readonly ApplicationDbContext _context;

        public CardListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CardListExists(long id)
        {
            return await _context.CardLists.AnyAsync(l => l.Id == id);
        }

        public async Task<CardList> Create(CardList cardList)
        {
            await _context.CardLists.AddAsync(cardList);
            await _context.SaveChangesAsync();

            return cardList;
        }

        public async Task<CardList?> Delete(long id)
        {
            CardList cardList = await _context.CardLists.FirstOrDefaultAsync(l => l.Id == id);

            if(cardList == null)
            {
                return null;
            }

            _context.CardLists.Remove(cardList);
            await _context.SaveChangesAsync();

            return cardList;
        }

        public async Task<List<CardList>> GetAll(CardListQueryObject queryObject)
        {
            IQueryable<CardList> cardLists = _context.CardLists.AsQueryable();

            if(queryObject.BoardId != null)
            {
                cardLists = cardLists.Where(l => l.BoardId == queryObject.BoardId);
            }

            return await cardLists.ToListAsync();
        }

        public async Task<CardList> GetById(long id)
        {
            return await _context.CardLists.Include(l => l.Cards).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<CardList?> Update(long id, UpdateCardListDto updateCardListDto)
        {
            CardList cardList = await _context.CardLists.FirstOrDefaultAsync(l => l.Id == id);

            if (cardList == null)
            {
                return null;
            }

            cardList.Name = updateCardListDto.Name;
            cardList.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return cardList;
        }
    }
}
