using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController (ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? brandFilterapplied, int? typesFilterApplied)
        {
            var itemsOnPage = 10;
            var catalog = await _service.GetCatalogEventsAsync(page ?? 0, itemsOnPage, brandFilterapplied, typesFilterApplied);
            return View();
        }
    }
}