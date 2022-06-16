

using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{

    await _context.Products.AddAsync(new() { Name = "Barak12cal", Price = 1300, Stock = 123, Barcode = "123123123" });
    await _context.Products.AddAsync(new() { Name = "Barak12cal", Price = 1300, Stock = 123, Barcode = "123123123" });
    await _context.Products.AddAsync(new() { Name = "Barak12cal", Price = 1300, Stock = 123, Barcode = "123123123" });

    _context.SaveChanges();
    // ChangeTracker mekanizması veri tabanındaki datalara 


    await _context.Products.ForEachAsync(p =>
    {
         Console.WriteLine($"{p.Name} - {p.CreatedDate}");
    });


    // Birden fazla veri tabanımız varken bunları ayırt etmek için contextId'yi kullanıyoruz.
    Console.WriteLine($" Context ID : {_context.ContextId}");

    //var newProduct = new Product { Name = "Aug-Rest 12 cal", Price = 200, Barcode = "asdasd123", Stock = 15 };

    //Console.WriteLine($"ilk state : {_context.Entry(newProduct).State}"); // Bu arkadaş detached oldu track edilmedi daha o yüzden detached. Çünkü memory'de EFCore tarafından takip edilmiyor.

    //await _context.AddAsync(newProduct);

    //Console.WriteLine($"ikinci state : {_context.Entry(newProduct).State}"); // Bu arkadaş Added oldu 


    //await _context.SaveChangesAsync();

    //Console.WriteLine($"ucuncu state : {_context.Entry(newProduct).State}"); // Bu arkadaş Unchanced oldu çünkü veri tabanı ile burdaki datamız aynı bir işlem türüyle işaretlenmedi. Trackingde bir işlem beklemiyor.


    //newProduct.Stock = 1000;

    //Console.WriteLine($"dorduncu state : {_context.Entry(newProduct).State}"); // Bu arkadaş Moded oldu 

    //await _context.SaveChangesAsync();

    //Console.WriteLine($"en son state : {_context.Entry(newProduct).State}"); // Bu arkadaş Unchanced oldu çünkü veri tabanı ile burdaki datamız aynı bir işlem türüyle işaretlenmedi. Trackingde bir işlem beklemiyor.



    //var products = await _context.Products.ToListAsync();

    //products.ForEach(p =>
    //{
    //    Console.WriteLine($"{p.Id} : {p.Name} - {p.Price}");
    //});


}
