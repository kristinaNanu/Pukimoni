using Newtonsoft.Json;
using Pukimoni.Application.Exceptions;
using Pukimoni.Application.Logger;
using Pukimoni.Domain.Interfaces;
using System;
using System.Linq;

namespace Pukimoni.Application.BusinessLogic
{
    public class BaseHandler
    {
        private IUseCaseLogger _logger;
        private IApplicationUser user;

        public BaseHandler(IUseCaseLogger logger, IApplicationUser user)
        {
            _logger = logger;
            this.user = user;
        }

        public void HandleCommand<TRequest>(IBaseCommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLog(command, data);
                command.Execute(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IBaseQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLog(query, data);
                var response = query.Execute(data);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void HandleLog<TRequest>(IUseCase useCase, TRequest data)
        {
            var log = new UseCaseLog
            {
                Username = this.user.Identity,
                ExecutedOn = DateTime.UtcNow,
                ActionName = useCase.Name,
                UserId = this.user.Id,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = isAuthorized(useCase.Id)
            };

            _logger.Log(log);

            if (!isAuthorized(useCase.Id))
            {
                throw new UnauthorizedException();
            }

        }

        private bool isAuthorized(int id) => this.user.PermissionIds.Contains(id); 
        //dodati da je banovan also
    }
}
