using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogEventsAsync(int page, int size, int? host, int? type);
        Task<IEnumerable<SelectListItem>> GetHostsAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
    }
}
