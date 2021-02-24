using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RoofStockAssesment.Common.Entities
{
    public partial class PropertiesContext : DbContext
    {
        public PropertiesContext()
        {

        }
        public PropertiesContext(DbContextOptions<PropertiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Property> Properties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=Properties;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.GrossYield).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ListPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MonthlyRent).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.YearBuilt)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
