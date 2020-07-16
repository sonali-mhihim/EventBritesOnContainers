using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
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
        public string EventHost { get; set; }
        public string EventType { get; set; }
    }
}
