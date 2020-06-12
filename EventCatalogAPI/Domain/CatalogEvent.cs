using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EventCatalogAPI.Domain.CatalogHost;

namespace EventCatalogAPI.Domain
{
    public class CatalogEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int CatalogHostId { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogHost EventHost { get; set; }
        public CatalogEventType EventType { get; set; }

    }
}
