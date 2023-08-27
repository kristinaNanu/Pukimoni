using Pukimoni.Application.BusinessLogic.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.Queries
{
    public interface IGetUsersQuery : IBaseQuery<PaginationSearch, PaginationResult<UserDto>>
    {
    }
}
