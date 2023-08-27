using Pukimoni.Application.BusinessLogic.DTO;
using Pukimoni.Application.BusinessLogic.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.Queries
{
    public interface IGetPokemonsQuery : IBaseQuery<PaginationSearch, PaginationResult<PokemonDto>>
    {
    }
}
