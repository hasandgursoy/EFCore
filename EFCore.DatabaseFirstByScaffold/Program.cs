

using EFCore.DatabaseFirstByScaffold.Models;
using Microsoft.EntityFrameworkCore;

using (var dbContext = new EFCoreDBFirstContext())
{

    var products = await dbContext.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name} - {p.Price}");
    });


}