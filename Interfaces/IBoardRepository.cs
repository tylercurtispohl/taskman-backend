using taskman_backend.Dtos.Board;
using taskman_backend.Models;

namespace taskman_backend.Interfaces
{
    public interface IBoardRepository
    {
        Task<List<Board>> GetAll();
        Task<Board> GetById(long id);
        Task<Board> Create(Board board);
        Task<Board?> Update(long id, UpdateBoardDto updateBoardDto);
        Task<Board?> Delete(long id);
        Task<bool> BoardExists(long id);
    }
}
