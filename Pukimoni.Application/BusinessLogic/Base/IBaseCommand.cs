namespace Pukimoni.Application.BusinessLogic
{
    public interface IBaseCommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
}
