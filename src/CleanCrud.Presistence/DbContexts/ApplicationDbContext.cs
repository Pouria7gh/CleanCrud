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
        DbSet<RefreshToken> RefreshTokens { get; set; }

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

            builder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Token).IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(r => r.User)
                    .WithMany(u => u.RefreshTokens)
                    .HasForeignKey(r => r.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(r => r.CreatedByIp).IsRequired().HasMaxLength(45);

                entity.Property(r => r.RevokedByIp).HasMaxLength(45);

                entity.Property(r => r.ReplacedByToken).HasMaxLength(200);
            });
        }
    }
}
