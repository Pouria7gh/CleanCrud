using CleanCrud.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Presistence.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(p => new { p.ManufactureEmail, p.ProduceDate });

                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);

                entity.Property(p => p.ProduceDate).IsRequired();

                entity.Property(p => p.ManufacturePhone).IsRequired().HasMaxLength(20);

                entity.Property(p => p.ManufactureEmail).IsRequired().HasMaxLength(100);

                entity.Property(p => p.IsAvailable).IsRequired().HasDefaultValue(true);
            });
        }
    }
}
