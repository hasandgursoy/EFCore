using EFCore.CodeFirstRelations.DAL.Many_To_Many;
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
        public DbSet<Category> Categories { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
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
            // One to Manny
            // Bunu elle yazmayı sevdim.
            // Category'nin çok products'ı olabilir ancak products'ın bir tane category'si olabilir. En sonuna da Foreign ilişki için yapı kurduk.
            // Convention'a geri döndürdüm :D böyle kalması performansı azaltır.
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id);

            // One To One
            // Fluent Apı ile tanımladığımız yapılarda ForeignKey gelmiyorsa generic olarak vermemiz gerekiyor.
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductId);

            // One To One Other Way
            // Foreign key normalde napıyorduk product Feature içindeki prodcutId kullanıyoduk ancak bunun yerine direkt olarak ProductFeatureId de kullanılabilir.
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            // Many To Many
            //modelBuilder.Entity<Student>()
            //    .HasMany(x => x.Teachers)
            //    .WithMany(x => x.Students)
            //    .UsingEntity<Dictionary<string, object>>(
            //    "StudentTeacherManyToMany",
            //    x => x.HasOne<Teacher>().WithMany()
            //    .HasForeignKey("TeacherId").HasConstraintName("Fk_TeacherId"),
            //    x => x.HasOne<Student>().WithMany().
            //    HasForeignKey("StudentId").HasConstraintName("FK_StudentId")
            //    ); ;

            // Delete Behaviours

            // DeleteBehavior.Cascade
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).
            //    HasForeignKey(x => x.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade); // Bu yapı category silinirse bağlı olan productslarıda siler güvensizdir. Veri tutuarsızlığı oluşturur.

            // DeleteBehavior.Restrict
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).
            //    HasForeignKey(x => x.CategoryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // DeleteBehavior.SetNull 
            // Veriler silinince silinen kısım null atanır. Örnek Category'i sildik ancak product 'ın categoryId si null oldu
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).
            //    HasForeignKey(x => x.CategoryId)
            //    .OnDelete(DeleteBehavior.SetNull);


            // DatabaseGenereted Attribute

            // Otomatik olaarak kdv ve price çapılacak sonra kdvli price hesaplanacak.
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).HasComputedColumnSql("[Price]*[Kdv]");

            base.OnModelCreating(modelBuilder);
        }

    }
}
