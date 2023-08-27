using Pukimoni.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Application.BusinessLogic.DTO
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public eEntityStatus EntityStatus { get; set; }
    }
}
