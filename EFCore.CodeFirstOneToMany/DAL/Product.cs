using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirstRelations.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Barcode { get; set; }
        // EFCore CategoryId kelimesinden bağlantı kuruyor. Foreign key deniyor bu duruma.
        public int CategoryId { get; set; }
        // Navigation property oldu bu Category .
        public Category Category { get; set; }
    }
}
