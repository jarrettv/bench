using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bench.Models;
using bench.Infra;

namespace bench.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly Db _db;

        public ValuesController(Db db)
        {
            _db = db;
        }

        [HttpGet("api/getGenders")]
        public async Task<IEnumerable<Gender>> Get()
        {
            return await _db.GetAllGenders();
        }
    }
}
