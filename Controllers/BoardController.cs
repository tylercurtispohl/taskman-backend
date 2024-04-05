using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskman_backend.Dtos.Board;
using taskman_backend.Interfaces;
using taskman_backend.Mappers;
using taskman_backend.Models;

namespace taskman_backend.Controllers
{
    [Route("api/board")]
    [ApiController]
    [Authorize]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _boardRepo;

        public BoardController(IBoardRepository boardRepo)
        {
            _boardRepo = boardRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Board> boards = await _boardRepo.GetAll();

            return Ok(boards.Select(b => b.ToBoardDto()));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            Board board = await _boardRepo.GetById(id);

            if(board == null)
            {
                return NotFound();
            }

            return Ok(board.ToBoardDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBoardDto createBoardDto)
        {
            Board board = createBoardDto.ToBoardFromCreateBoardDto();

            await _boardRepo.Create(board);

            return Ok(board);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateBoardDto updateBoardDto)
        {
            Board board = await _boardRepo.Update(id, updateBoardDto);

            if(board == null)
            {
                return NotFound();
            }

            return Ok(board.ToBoardDto());
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            Board board = await _boardRepo.Delete(id);

            if( board == null)
            {
                return NotFound();
            }

            return Ok(board.ToBoardDto());
        }
    }
}
