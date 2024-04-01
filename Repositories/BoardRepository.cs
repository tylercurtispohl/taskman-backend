using Microsoft.EntityFrameworkCore;
using taskman_backend.Data;
using taskman_backend.Dtos.Board;
using taskman_backend.Interfaces;
using taskman_backend.Models;

namespace taskman_backend.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ApplicationDbContext _context;

        public BoardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BoardExists(long id)
        {
            return await _context.Boards.AnyAsync(b => b.Id == id);
        }

        public async Task<Board> Create(Board board)
        {
            await _context.Boards.AddAsync(board);
            await _context.SaveChangesAsync();

            return board;
        }

        public async Task<Board?> Delete(long id)
        {
            Board board = await _context.Boards.FirstOrDefaultAsync(b => b.Id == id);

            if(board == null)
            {
                return null;
            }

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return board;
        }

        public async Task<List<Board>> GetAll()
        {
            return await _context.Boards.ToListAsync();
        }

        public async Task<Board> GetById(long id)
        {
            return await _context.Boards.Include(b => b.CardLists).ThenInclude(cl => cl.Cards).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Board?> Update(long id, UpdateBoardDto updateBoardDto)
        {
            Board board = await _context.Boards.FirstOrDefaultAsync(b => b.Id == id);

            if (board == null)
            {
                return null;
            }

            board.Name = updateBoardDto.Name;
            board.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return board;
        }
    }
}
