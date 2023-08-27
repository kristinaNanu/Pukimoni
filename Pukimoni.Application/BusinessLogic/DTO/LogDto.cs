using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.DTO
{
    public class LogDto : BaseDto
    {
        public string Username { get; set; }
        public string ActionName { get; set; }
        public string ExecutedOn { get; set; }
    }
}
