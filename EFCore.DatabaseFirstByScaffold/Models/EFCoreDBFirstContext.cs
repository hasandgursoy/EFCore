using System;
using System.Collections.Generic;
using EFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EFCore.DatabaseFirstByScaffold.Models
{
    public partial class EFCoreDBFirstContext : DbContext
    {

        /* Nuget Paket Manager'a yazıyoruz.
         * Scaffold-DbContext "Server=127.0.0.1;Port=5432;Database=EFCoreDBFirst;User Id=postgres;Password=postgres;"
         * NpgSql.EntityFrameworkCore.PostgreSQL -OutputDir Models
         */

        public EFCoreDBFirstContext()
        {
        }

        public EFCoreDBFirstContext(DbContextOptions<EFCoreDBFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(DbContextInitiliazer.configuration.GetConnectionString("PostgreSQL"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).HasColumnType("char");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
