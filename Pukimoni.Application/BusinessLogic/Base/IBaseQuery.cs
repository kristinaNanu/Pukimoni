namespace Pukimoni.Application.BusinessLogic
{
    public interface IBaseQuery<TRequest, TResult> : IUseCase
    {
        TResult Execute(TRequest search);
    }
}
