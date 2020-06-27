using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext catalogContext)
        {
            catalogContext.Database.Migrate();
            if (!catalogContext.CatalogHosts.Any()) { 
                catalogContext.CatalogHosts.AddRange(GetCatalogHosts());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.CatalogEventTypes.Any())
            {
                catalogContext.CatalogEventTypes.AddRange(GetCatalogTypes());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.CatalogEvents.Any())
            {
                catalogContext.CatalogEvents.AddRange(GetCatalogEvents());
                catalogContext.SaveChanges();

            }

        }

        private static IEnumerable<CatalogHost> GetCatalogHosts()
        {
            return new List<CatalogHost>
            {
                new CatalogHost
                {
                    Name = "Coffee Makers Co.",
                    Description = "Best kitchen appliance brand that delivers innovation based on consumer insights"
                },
                new CatalogHost
                {
                    Name = "Mermaid Reserve",
                    Description ="Coffee and Wine. Tours and Experience"
                },
                new CatalogHost
                {
                    Name="School of Meditation",
                    Description="School of Yoga and Meditation in Seattle"
                },
                new CatalogHost
                {
                    Name="Woodland Park Zoo",
                    Description="American zoological garden located in Seattle"
                },
                new CatalogHost
                {
                    Name="Health Is Wealth",
                    Description="National American Running Society"
                }

            };

        }

        private static IEnumerable<CatalogEventType> GetCatalogTypes()
        {
            return new List<CatalogEventType>
            {
                new CatalogEventType
                {
                    Name = "Family Friendly"
                },
                new CatalogEventType
                {
                    Name = "Mindfulness"
                },
                new CatalogEventType
                {
                    Name="Tourism"
                },
                new CatalogEventType
                {
                    Name="Fitness"
                }
            };

        }

        private static IEnumerable<CatalogEvent> GetCatalogEvents()
        {
            return new List<CatalogEvent>()
            {
                new CatalogEvent { CatalogTypeId = 2, CatalogHostId = 3, Description = "Join the world wide celebrations for the United Nations International Day of Yoga.", Name = "Yoga Day Festival", Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1", Date=new DateTime(2020,6,20), Location="Woodland Park Zoo, Seattle" },
                new CatalogEvent { CatalogTypeId = 3, CatalogHostId = 4, Description = "Cheers to conservation! Brew at the Zoo is back and you can enjoy imports, domestics, microbrews, and ciders from 60+ different breweries.", Name = "Brew at the Zoo", Price = 50.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2", Date=new DateTime(2020,6,20), Location="Woodland Park Zoo, Seattle" },
                new CatalogEvent { CatalogTypeId = 1, CatalogHostId = 4, Description = "Featuring different flavors from the finest ice cream companies, this family-friendly event will have live entertainment, food trucks, an ice cream eating contest, games, and much more!", Name = "Ice cream at the Zoo", Price = 35, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3", Date=new DateTime(2020,9,15), Location="Woodland Park Zoo, Seattle" },
                new CatalogEvent { CatalogTypeId = 3, CatalogHostId = 1, Description = "Travel the world of coffee and more on this 1 hour espresso crash course", Name = "Coffee Workshop", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4", Date=new DateTime(2020,10,9), Location="Bellevue, WA" },
                new CatalogEvent { CatalogTypeId = 1, CatalogHostId = 2, Description = "Teens are invited to make Internet-famous iced whipped/dalgona coffee", Name = "Whipped Dalgona Iced Coffee", Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5", Date=new DateTime(2020,7,18), Location="Coffee Reserve at Downtown Park, Sammamish" },
                new CatalogEvent { CatalogTypeId = 2, CatalogHostId = 3, Description = "Kidding around yoga blends the teachings and values of traditional yoga", Name = "Mommy and Me Yoga session", Price = 5, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6", Date=new DateTime(2020,11,11), Location="School of Meditation"},
                new CatalogEvent { CatalogTypeId = 2, CatalogHostId = 3, Description = "Learn about meditation, it's history, it's benefits and how to do it", Name = "Online Meditation Event", Price = 50, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7", Date=new DateTime(2020,9,6), Location="Online event" },
                new CatalogEvent { CatalogTypeId = 4, CatalogHostId = 5, Description = "Running Through Runyon Canyon", Name = "Running in Runyon", Price = 99, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8", Date=new DateTime(2020,9,6), Location="Runyon Canyon" },
            };
        }
        
    }
}

