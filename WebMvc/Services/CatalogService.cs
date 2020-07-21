using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Services;

namespace WebMvc.Models
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;
        public CatalogService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["CatalogUrl"]}/api/catalog/";
            _client = client;
        }
        public async Task<Catalog> GetCatalogEventsAsync(int page, int size, int? host, int? type)
        {
            var catalogItemsUri = ApiPaths.Catalog.GetAllCatalogEvents(_baseUrl, page, size, host, type);
            var dataString = await _client.GetStringAsync(catalogItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetHostsAsync()
        {
            var hostUri = ApiPaths.Catalog.GetAllHosts(_baseUrl);
            var dataString = await _client.GetStringAsync(hostUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value= null,
                    Text = "All",
                    Selected = true
                }
            };
            var hosts = JArray.Parse(dataString);
            foreach (var host in hosts)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = host.Value<string>("id"),
                        Text = host.Value<string>("name")
                    });
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = ApiPaths.Catalog.GetAllTypes(_baseUrl);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value= null,
                    Text = "All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("name")
                    });
            }
            return items;
        }
    }
}
