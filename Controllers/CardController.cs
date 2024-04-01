using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskman_backend.Dtos.Card;
using taskman_backend.Interfaces;
using taskman_backend.Mappers;
using taskman_backend.Models;

namespace taskman_backend.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepo;
        private readonly ICardListRepository _cardListRepo;

        public CardController(ICardRepository cardRepo, ICardListRepository cardListRepo)
        {
            _cardRepo = cardRepo;
            _cardListRepo = cardListRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Card> cards = await _cardRepo.GetAll();

            return Ok(cards.Select(c => c.ToCardDto()));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            Card card = await _cardRepo.GetById(id);

            if(card == null)
            {
                return NotFound();
            }

            return Ok(card.ToCardDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardDto createCardDto)
        {
            if(!(await _cardListRepo.CardListExists(createCardDto.CardListId)))
            {
                return BadRequest("List does not exist");
            }

            Card card = createCardDto.ToCardFromCreateCardDto();

            await _cardRepo.Create(card);

            return Ok(card.ToCardDto());
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateCardDto updateCardDto)
        {
            if(!(await _cardListRepo.CardListExists(updateCardDto.CardListId)))
            {
                return BadRequest("List does not exist");
            }

            Card card = await _cardRepo.Update(id, updateCardDto);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card.ToCardDto());
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            Card card = await _cardRepo.Delete(id);

            if(card == null)
            {
                return NotFound();
            }

            return Ok(card.ToCardDto());
        }
    }
}

