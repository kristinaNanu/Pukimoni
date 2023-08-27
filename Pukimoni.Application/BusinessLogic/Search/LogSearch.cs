using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.Search
{

    public class LogSearch : PaginationSearch
    {
        public string Username { get; set; }
        public string ActionName { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
    }
}
