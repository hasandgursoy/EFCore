﻿

using EFCore.CodeFirstRelations;
using EFCore.CodeFirstRelations.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();



using (var _context = new AppDbContext())
{
    // Eager Loading

    // Eager Loading = Veriyi alırken beraberinde bağımlı başka verileri de istemek.
    //var categoryWithProducts = _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature);


    // Explicit Loading

    // Explicit Loading = İhtiyaç durumuna göre sonra çekme
    //var category = _context.Categories.First();

    //if (true)
    //{
    //    Çoka Çok ilişkilerde Collection İfadesi
    //    _context.Entry(category).Collection(x => x.Products).Load();

    //}

    //var product = _context.Products.First();

    //if (true)
    //{   // Birebir bir ilişkiler de Reference
    //    _context.Entry(product).Reference(x => x.ProductFeature).Load();
    //}


}