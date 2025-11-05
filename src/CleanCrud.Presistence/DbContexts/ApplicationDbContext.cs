using CleanCrud.Domain.Entities;
using CleanCrud.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Presistence.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Product> Products { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);

                entity.Property(p => p.ProduceDate).IsRequired();

                entity.Property(p => p.Quantity).IsRequired().HasDefaultValue(0);
            });

            builder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Name).IsRequired().HasMaxLength(100);

                entity.Property(m => m.Email).IsRequired().HasMaxLength(150);
            });
        }
    }
}
