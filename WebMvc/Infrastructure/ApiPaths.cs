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
            public static string GetAllEventTypes(string baseUri)
            {
                return $"{baseUri}catalogtypes";
            }
            public static string GetAllHosts(string baseUri)
            {
                return $"{baseUri}cataloghosts";
            }
            public static string GetAllCatalogItems(string baseUri, int page, int take, int? host, int? type)
            {
                var filterQs = string.Empty;
                if (host.HasValue || type.HasValue)
                {
                    var hostQs = (host.HasValue) ? host.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/brand/{hostQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }
}
