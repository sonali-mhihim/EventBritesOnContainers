using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}catalogeventtypes";
            }
            public static string GetAllHosts(string baseUri)
            {
                return $"{baseUri}cataloghosts";
            }
            public static string GetAllCatalogEvents(string baseUri, int page, int take, int? host, int? type)
            {
                var filterQs = string.Empty;
                if (host.HasValue || type.HasValue)
                {
                    var hostQs = (host.HasValue) ? host.Value.ToString() : "   ";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "   ";
                    filterQs = $"/type/{typeQs}/host/{hostQs}";
                }
                return $"{baseUri}events{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }
    }
}
