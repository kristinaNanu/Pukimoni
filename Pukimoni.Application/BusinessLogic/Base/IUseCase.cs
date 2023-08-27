namespace Pukimoni.Application.BusinessLogic
{
    public interface IUseCase
    {
        public int Id { get; }
        string Name { get; }
        string Description { get; }
    }
}
