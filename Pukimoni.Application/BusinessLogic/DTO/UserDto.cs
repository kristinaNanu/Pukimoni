using Pukimoni.Application.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
