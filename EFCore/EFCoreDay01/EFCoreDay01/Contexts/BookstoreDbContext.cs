using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDay01.Models;

namespace EFCoreDay01.Contexts
{
    public class BookstoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-VMQPVJ0;Database=BookstoreDB;Trusted_Connection=True;TrustServerCertificate = True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(150);
            builder.Entity<Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(8,2)");
            builder.Entity<Book>()
                .Property(b => b.PublishedDate)
                .IsRequired(false);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
