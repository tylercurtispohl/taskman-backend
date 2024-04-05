using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskman_backend.Dtos.CardList;
using taskman_backend.Helpers;
using taskman_backend.Interfaces;
using taskman_backend.Mappers;
using taskman_backend.Models;

namespace taskman_backend.Controllers
{
    [Route("api/cardlist")]
    [ApiController]
    [Authorize]
    public class CardListController : ControllerBase
    {
        private readonly ICardListRepository _cardListRepo;
        private readonly IBoardRepository _boardRepo;

        public CardListController(ICardListRepository cardListRepo, IBoardRepository boardRepo)
        {
            _cardListRepo = cardListRepo;
            _boardRepo = boardRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CardListQueryObject queryObject)
        {
            List<CardList> cardLists = await _cardListRepo.GetAll(queryObject);

            return Ok(cardLists.Select(l => l.ToCardListDto()));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            CardList cardList = await _cardListRepo.GetById(id);

            if(cardList == null)
            {
                return NotFound();
            }

            return Ok(cardList.ToCardListDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardListDto createCardListDto)
        {
            if(!(await _boardRepo.BoardExists(createCardListDto.BoardId)))
            {
                return BadRequest("Board does not exist");
            }

            CardList cardList = createCardListDto.ToCardListFromCreateCardListDto();

            await _cardListRepo.Create(cardList);

            return Ok(cardList.ToCardListDto());
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateCardListDto updateCardListDto)
        {
            CardList cardList = await _cardListRepo.Update(id, updateCardListDto);

            if(cardList == null)
            {
                return NotFound();
            }

            return Ok(cardList.ToCardListDto());
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            CardList cardList = await _cardListRepo.Delete(id);

            if(cardList == null)
            {
                return NotFound();
            }

            return Ok(cardList.ToCardListDto());
        }
    }
}
