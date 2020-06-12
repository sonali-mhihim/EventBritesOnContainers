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
                e.Property(c => c.Id).IsRequired().UseHiLo("catalog_event_hilo");
                e.Property(c => c.Name).IsRequired().HasMaxLength(100);
                e.Property(c => c.Price).IsRequired();
                e.Property(c => c.Date).IsRequired() .HasColumnType("Date");
                e.Property(c => c.Location).IsRequired() .HasColumnName("Location") .HasMaxLength(200);
                e.HasOne(c => c.EventHost).WithMany().HasForeignKey(c => c.CatalogHostId);
                e.HasOne(c => c.EventType).WithMany().HasForeignKey(c => c.CatalogTypeId);
            });

            modelBuilder.Entity<CatalogEventType>(e =>
            {
                e.ToTable("CatalogEventTypes");
                e.Property(t => t.Id).IsRequired().UseHiLo("catalog_types_hilo");
                e.Property(t => t.Name).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<CatalogHost>(e =>
            {
                e.ToTable("CatalogEventHosts");
                e.Property(h => h.Id).IsRequired().UseHiLo("catalog_hosts_hilo");
                e.Property(h => h.Name).IsRequired().HasMaxLength(100);
                e.Property(h => h.Description).IsRequired().HasMaxLength(200);
            });
        }
    }
}
