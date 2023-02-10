using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApIUnitOfWork.Contracts;
using WebApIUnitOfWork.Models;

namespace WebApIUnitOfWork.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class TablaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TablaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public  async Task<IReadOnlyList<Tabla>> GetTabla()
        {
            IReadOnlyList<Tabla> TablaList = null;

            TablaList = await _unitOfWork.tablaRepository.GetAllAsync();

            return TablaList;
        }
    }
}
