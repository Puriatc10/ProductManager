using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductManagerTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Persistance.Context
{
    public class DataBaseContext : IdentityDbContext<User , Role , Guid>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductOwner)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(255);
            modelBuilder.Entity<Product>()
                .Property(p => p.ManufactureEmail)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ManufactureEmail)
                .IsUnique();
            modelBuilder.Entity<Product>()
                .Property(p => p.ManufacturePhone)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Product>()
                .Property(p => p.ProduceDate)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProduceDate)
                .IsUnique();
        }
    }
}
