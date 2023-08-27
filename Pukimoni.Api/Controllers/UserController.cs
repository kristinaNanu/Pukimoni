using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private BaseHandler _handler;
        public UserController(BaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("{id}")]
        //[HttpGet]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetUserQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }


        //[HttpGet("GetUsers")]
        //public IActionResult GetUsers([FromBody] PaginationSearch search, [FromServices] IGetUsersQuery query)
        [HttpGet]
        public IActionResult Get([FromBody] PaginationSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CreateUserDto dto, [FromServices] ICreateUserCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        [HttpPut("{id}")] 
        //[HttpPut] 
        public IActionResult Put(int id, [FromBody] UpdateUserDto dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }  

        [HttpPut("BanUserToggle/{id}")] 
        //[HttpPut] 
        public IActionResult BanUserToggle(int id, [FromServices] IBanUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        //[HttpDelete]
        [AllowAnonymous]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }

        //pokedex ide ovde zato sto samo moze da se pregleda, nista se ne brise iz pokedex-a, a update-uje se samo kada se uhvati pokemon
        
         [HttpGet("Pokedex")]
        public IActionResult Pokedex([FromBody] PaginationSearch search, [FromServices] IGetPokedexQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

         [HttpGet("Logs")]
        public IActionResult Logs([FromBody] LogSearch search, [FromServices] IGetLogQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
         
    }
}
