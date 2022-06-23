

using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();
// EF Core'un harika bir document yapısı var sitesine kesinlikle sürekli girilip bakılması gerekir.
using (var _context = new AppDbContext())
{

    
    
    
    
    
    // --- DbSet<> Methodları ---//
    // FirstOrDefault da olay ilk ini alır yoksa null döner default olarak null dır.
    //var product =  _context.Products.FirstOrDefault(x => x.Id == 100, new Product() { Id = 1, Name = "Silgi" }) ;
    //var product1 = await  _context.Products.SingleAsync(x => x.Stock > 100);
    //var product2 = await _context.Products.Where(x => x.Id > 10 || x.Price ==100).ToListAsync();
    //var product3 = await _context.Products.FindAsync(10); // direkt olarak primary key içinde arar.
    //var product4 = _context.Products.AsNoTracking().FirstAsync(x => x.Name.Length > 10); // Veriyi takip etme.




    //await _context.Products.AddAsync(new() { Name = "Barak12cal", Price = 1300, Stock = 123, Barcode = "123123123" });
    //await _context.Products.AddAsync(new() { Name = "Barak12cal", Price = 1300, Stock = 123, Barcode = "123123123" });
    //await _context.Products.AddAsync(new() { Name = "Barak12cal", Price = 1300, Stock = 123, Barcode = "123123123" });

    //_context.SaveChanges();
    //// ChangeTracker mekanizması veri tabanından önce ve sonraki durumları takip eder.


    //await _context.Products.ForEachAsync(p =>
    //{
    //     Console.WriteLine($"{p.Name} - {p.CreatedDate}");
    //});

    // _context.Add ile _context.Products.Add arasında hiç bir fark yoktur.
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
