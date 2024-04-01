using Microsoft.EntityFrameworkCore;
using taskman_backend.Data;
using taskman_backend.Dtos.Card;
using taskman_backend.Interfaces;
using taskman_backend.Models;

namespace taskman_backend.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Card> Create(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

            return card;
        }

        public async Task<Card?> Delete(long id)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if(card == null)
            {
                return null;
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return card;
        }

        public async Task<List<Card>> GetAll()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card> GetById(long id)
        {
            return await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Card?> Update(long id, UpdateCardDto updateCardDto)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if (card == null)
            {
                return null;
            }

            card.CardListId = updateCardDto.CardListId;
            card.Name = updateCardDto.Name;
            card.Description = updateCardDto.Description;
            card.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return card;
        }
    }
}
