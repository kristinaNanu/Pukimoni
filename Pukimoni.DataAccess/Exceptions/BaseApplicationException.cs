﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.DataAccess.Exceptions
{
    public abstract class BaseApplicationException : Exception
    {
        protected BaseApplicationException(string message) 
            : base(message)
        {
        }
    }
}
