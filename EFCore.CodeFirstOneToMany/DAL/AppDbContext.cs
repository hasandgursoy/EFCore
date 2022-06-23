using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirstRelations.DAL
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Product> Products { get; set; }


        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                
                

                if (e.Entity is Product p)
                {

                    if (e.State == EntityState.Added)
                    {
                        p.CreatedDate = DateTime.UtcNow;

                    }

                }
            });

            return base.SaveChanges();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Console uygulması oldugu için bunu burda bir kere build etmemiz lazım.
            Initializer.Build();
            optionsBuilder.UseNpgsql(Initializer.Configuration.GetConnectionString("PostgreSQL"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bunu elle yazmayı sevdim.
            // Category'nin çok products'ı olabilir ancak products'ın bir tane category'si olabilir. En sonuna da Foreign ilişki için yapı kurduk.
            // Convention'a geri döndürdüm :D böyle kalması performansı azaltır.
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id);


            base.OnModelCreating(modelBuilder);
        }

    }
}
