

using EFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContextInitiliazer.Build();

using (var _context = new AppDBContext(DbContextInitiliazer.optionsBuilder.Options))
{
    // using'in kullanılma sebebi AppDBContext ağır bir nesne olduğu için bunu bu blokdan çıkar çıkmaz dispose edecek.
    var products =  await _context.Products.ToListAsync();

    products.ForEach(p =>
    {

        Console.WriteLine($"{p.Id} : {p.Name}");
    
    });

}

