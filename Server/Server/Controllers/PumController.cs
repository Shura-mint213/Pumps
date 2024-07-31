using Shared.Models.Tabels;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Tabels;
using Shared.Interfaces;
using Shared.Counts;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PumController : Controller
    {
        private readonly IPumpsRepository _pumpsRepository;
        public PumController(IPumpsRepository pumpsRepository) 
        {
            _pumpsRepository = pumpsRepository;
        }

        [Route("GetList")]
        [HttpGet]
        public async Task<List<Pump>> GetPumps(int page = 0,
            int count = PageSettings.NumberOfElementsPerPage)
        {
            int skip = page * count;
            return await _pumpsRepository.GetListAsync(skip, count);
        }
    }
}
