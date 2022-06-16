using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DatabaseFirst.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected AppDBContext()
        {
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DbContextInitiliazer.configuration.GetConnectionString("PostgreSQL"));
        }

    }
}


// Öncelikle En Sağlılık yöntem CodeFirst yaklaşımıdır.
// add-migration mig_name1 = migration ekler
// update-database = migration'ı veritabanına yansıtır.
// remove-migration = son migration'ı siler
// Hata yaptık diyelim son migration'ıda yansıttık yanlışlıkla ama onu silmemiz lazım
// update-migration sondanOncekiMigration_1 diyoruz bir önceki migration'a güncelledik.
// daha sonra remove-migration diyoruz.
// Eğer bize script lazımsa :
// script-migration = diyoruz ve bize migration'ın scriptlerini veriyor.
