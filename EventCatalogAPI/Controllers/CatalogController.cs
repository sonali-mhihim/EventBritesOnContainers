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
        public async Task<IActionResult> Events([FromQuery]int pageIndex = 0,[FromQuery]int pagesize = 3)
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
            events.ForEach(events => events.PictureUrl = events.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogBaseUrl"]));
            return events;
        }
    }
}