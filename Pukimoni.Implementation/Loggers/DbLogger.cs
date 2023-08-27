using Pukimoni.Application.Logger;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.Loggers
{
    public class DbLogger : IUseCaseLogger
    {
        private PukimoniContext _context;
        public DbLogger(PukimoniContext context) => _context = context;

        public void Log(UseCaseLog log)
        {
            var newLog = new Log
            {
                UserId = log.UserId,
                Username = log.Username,
                ExecutedOn = log.ExecutedOn,
                Data = log.Data,
                IsAuthorized = log.IsAuthorized,
                Action = log.ActionName,
            };
            _context.Logs.Add(newLog);
            _context.SaveChanges();
        }
    }
}
