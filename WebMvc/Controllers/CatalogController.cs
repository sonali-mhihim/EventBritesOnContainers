using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController (ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? hostFilterapplied, int? typesFilterApplied)
        {
            var eventsOnPage = 5;
            var catalog = await _service.GetCatalogEventsAsync(page ?? 0, eventsOnPage, hostFilterapplied, typesFilterApplied);
            var vm = new CatalogIndexViewModel
            {
                CatalogEvents = catalog.Data,
                Hosts = await _service.GetHostsAsync(),
                Types = await _service.GetTypesAsync(),
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    EventsPerPage = catalog.PageSize,
                    TotalEvents = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count/eventsOnPage)
                },
                HostFilterApplied = hostFilterapplied?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0
            };
            return View(vm);
            
        }
    }
}