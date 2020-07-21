using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;

        public CatalogController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Events([FromQuery]int pageIndex = 0, [FromQuery]int pagesize = 3)
        {
            var eventsCount = await _context.CatalogEvents.LongCountAsync();
            var events = await _context.CatalogEvents
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pagesize)
                .Take(pagesize)
                .ToListAsync();

            events = ChangePictureUrl(events);
            var model = new PaginatedEventsViewModel<CatalogEvent>
            {
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount,
                Data = events
            };
            return Ok(model);
        }

        private List<CatalogEvent> ChangePictureUrl(List<CatalogEvent> events)
        {
            events.ForEach(e =>
                        e.PictureUrl = e.PictureUrl.Replace(
                                    "http://externalcatalogbaseurltobereplaced",
                                    _config["ExternalCatalogBaseUrl"]));
            return events;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var types = await _context.CatalogEventTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogHosts()
        {
            var hosts = await _context.CatalogHosts.ToListAsync();
            return Ok(hosts);
        }

        [HttpGet("[action]/type/{catalogTypeId}/host/{catalogHostId}")]
        public async Task<IActionResult> Events(
            int? catalogTypeId,
            int? catalogHostId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6
            )
        {
            var query = (IQueryable<CatalogEvent>)_context.CatalogEvents;

            if (catalogTypeId.HasValue)
            {
                query = query.Where(c => c.CatalogTypeId == catalogTypeId);
            }

            if (catalogHostId.HasValue)
            {
                query = query.Where(c => c.CatalogHostId == catalogHostId);
            }

            var events = await query
                            .OrderBy(c => c.Date)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            var eventsCount = query.LongCountAsync();

            events = ChangePictureUrl(events);

            var model = new PaginatedEventsViewModel<CatalogEvent>
            {
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount.Result,
                Data = events
            };

            return Ok(model);
        }
    }
}