using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Domain.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime ExecutedOn { get; set; }
        public string Data { get; set; }
        public bool IsAuthorized { get; set; }
        //public bool IsBlacklisted { get; set; }

        
    }
}
