using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        //server constructor for dependency injection
        public CatalogContext(DbContextOptions options) : base (options)
        {

        }
        public DbSet<CatalogEventType> CatalogEventTypes { get; set; }
        public DbSet<CatalogHost> CatalogHosts { get; set; }
        public DbSet<CatalogEvent> CatalogEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogEvent>(e =>
            {
                e.ToTable("CatalogEvents");
                e.Property(b => b.Id).IsRequired().UseHiLo("catalog_event_hilo");
                e.Property(b => b.Name).IsRequired().HasMaxLength(100);
                e.Property(b => b.Price).IsRequired();
                e.HasOne(b => b.EventHost).WithMany().HasForeignKey(c => c.CatalogHostId);
                e.HasOne(b => b.EventType).WithMany().HasForeignKey(c => c.CatalogTypeId);
            });

            modelBuilder.Entity<CatalogEventType>(e =>
            {
                e.ToTable("CatalogEventTypes");
                e.Property(b => b.Id).IsRequired().UseHiLo("catalog_types_hilo");
                e.Property(b => b.Name).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<CatalogHost>(e =>
            {
                e.ToTable("CatalogEventHosts");
                e.Property(b => b.Id).IsRequired().UseHiLo("catalog_hosts_hilo");
                e.Property(b => b.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
}
