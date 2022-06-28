

using EFCore.CodeFirstRelations;
using EFCore.CodeFirstRelations.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();



using (var _context = new AppDbContext())
{

    // Eager Loading = Veriyi alırken beraberinde bağımlı başka verileri de istemek.
    var categoryWithProducts = _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature);




}