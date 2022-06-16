using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DatabaseFirst.DAL
{
    public class DbContextInitiliazer
    {
        public static IConfigurationRoot configuration; // Appsettings'e ulaşabilmek için gerekliydi.
        public static DbContextOptionsBuilder<AppDBContext> optionsBuilder;


        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true,reloadOnChange:true);

            configuration = builder.Build();

            //optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            //optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
        }


    }
}
