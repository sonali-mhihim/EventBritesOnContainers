using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;

        public CatalogController(CatalogContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pagesize = 3)
        { var events = await _context.CatalogEvents
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pagesize)
                .Take(pagesize)
                .ToListAsync();

            return Ok(events);
        }
    }
}