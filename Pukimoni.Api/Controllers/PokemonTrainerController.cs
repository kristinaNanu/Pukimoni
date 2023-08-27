using Microsoft.AspNetCore.Mvc;
using Pukimoni.Application.BusinessLogic;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.Application.BusinessLogic.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pukimoni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonTrainerController : ControllerBase
    {

        private BaseHandler _handler;
        public PokemonTrainerController(BaseHandler handler)
        {
            _handler = handler;
        }

        //send help
        
        [HttpGet("TrainerPokemon")]
        public IActionResult TrainerPokemon([FromBody] PaginationSearch search, [FromServices] IGetTrainerPokemonQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpPost("CatchPokemon")]
        public IActionResult CatchPokemon([FromBody] CatchPokemonDto dto, [FromServices] ICatchPokemonCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        [HttpPut("FavoritePokemonToggle/{id}")] //za tog usera update-uj njegovog pokemona da je fav/unfav
        public IActionResult FavoritePokemonToggle(int id, [FromServices] IFavoritePokemonCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }

        [HttpDelete("TransferPokemon/{id}")]
        public IActionResult TransferPokemon(int id, [FromServices] ITransferPokemonCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }

    }
}
