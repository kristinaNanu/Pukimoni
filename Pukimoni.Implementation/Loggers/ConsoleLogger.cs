﻿using Pukimoni.Application.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(Exception ex)
        {
            Console.WriteLine("Occured at: " + DateTime.UtcNow);
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.Data);
        }
    }
}
