using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirstRelations.DAL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Burda da many işlemi gerçekleştirdik. Navigation Property verdik bunun için.
        // ICollection kullanmak avantajlıdır. İleride linked list gibi yapılar kullanmak istersek kolaylık sağlar.
        public ICollection<Product> Products { get; set; }
        


    }
}
