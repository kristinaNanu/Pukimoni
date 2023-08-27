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
    public class RegionController : ControllerBase
    {
        private BaseHandler _handler;
        public RegionController(BaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetRegionQuery query)
        {
            return Ok(_handler.HandleQuery(query, id)); ;
        }

        [HttpGet]
        public IActionResult Get([FromBody] PaginationSearch search, [FromServices] IGetRegionsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search)); ;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LookupDto dto, [FromServices] ICreateRegionCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LookupDto dto, [FromServices] IUpdateRegionCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRegionCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
