using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.Search
{
    public class PaginationSearch : BaseSearch
    {
        public int? Page { get; set; } = 1;
        public int? PerPage { get; set; } = 10;
    }
}
