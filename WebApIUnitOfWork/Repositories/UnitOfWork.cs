using System.Collections;
using WebApIUnitOfWork.Contracts;
using WebApIUnitOfWork.Models;

namespace WebApIUnitOfWork.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;

        private readonly ApplicationDbContext _context;

        private ITablaRepository _tablaRepository;
        public ITablaRepository tablaRepository => _tablaRepository ??
            new TablaRepository(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext applicationDbContext => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepositoryFastidio<TEntity> Repository<TEntity>() where TEntity : class, new()
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepositoryFastidio<TEntity>)_repositories[type];
        }
    }
}
