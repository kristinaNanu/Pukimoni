using Pukimoni.Application.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.Queries
{
    public interface IGetRegionQuery : IBaseQuery<int, LookupDto>
    {
    }
}
