using WebApIUnitOfWork.Contracts;
using WebApIUnitOfWork.Models;

namespace WebApIUnitOfWork.Repositories
{
    public class TablaRepository : RepositoryBase<Tabla>, ITablaRepository
    {
        public TablaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
