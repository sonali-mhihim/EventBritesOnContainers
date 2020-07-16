using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Hosts { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<CatalogEvent> CatalogEvents { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? BrandFilterApplied { get; set; }
        public int? TypeFilterApplied { get; set; }
    }
}
