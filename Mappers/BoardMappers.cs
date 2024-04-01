using taskman_backend.Dtos.Board;
using taskman_backend.Models;

namespace taskman_backend.Mappers
{
    public static class BoardMappers
    {
        public static BoardDto ToBoardDto(this Board board)
        {
            return new BoardDto
            {
                Id = board.Id,
                CreatedAt = board.CreatedAt,
                UpdatedAt = board.UpdatedAt,
                Name = board.Name,
                CardLists = board.CardLists.Select(l => l.ToCardListDto()).ToList()
            };
        }

        public static Board ToBoardFromCreateBoardDto(this CreateBoardDto createBoardDto)
        {
            return new Board
            {
                Name = createBoardDto.Name,
            };
        }
    }
}
