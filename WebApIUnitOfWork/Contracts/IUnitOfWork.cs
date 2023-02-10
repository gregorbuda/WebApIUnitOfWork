namespace WebApIUnitOfWork.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ITablaRepository tablaRepository { get; }

        IAsyncRepositoryFastidio<TEntity> Repository<TEntity>() where TEntity : class, new();
    }
}
