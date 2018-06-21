using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication11.QueryTypes;

namespace WebApplication11.Models
{
    public partial class soContext : DbContext
    {

        public soContext()
        {
        }

        public soContext(DbContextOptions<soContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=so;Username=postgres;Password=qwe123qwe123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
