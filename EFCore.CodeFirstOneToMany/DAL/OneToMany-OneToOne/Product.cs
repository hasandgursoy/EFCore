using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirstRelations.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Precision(18,2)]
        public decimal Price { get; set; }
        //public decimal  Kdv { get; set; }
        public int Stock { get; set; }

        // Insert ve Uptadate bu alan gönderilmeyecek çünkü hesaplama yapılan bir alan sadece.
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal  PriceKdv { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // İnsert işleminde dahil et ama update işleminde dahil etme.
        public DateTime? CreatedDate { get; set; }
        public string Barcode { get; set; }
        // EFCore CategoryId kelimesinden bağlantı kuruyor. Foreign key deniyor bu duruma.
        public int CategoryId { get; set; }
        // Navigation property oldu bu Category .
        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }

    }
}
