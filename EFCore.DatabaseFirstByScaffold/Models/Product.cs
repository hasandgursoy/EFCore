using System;
using System.Collections.Generic;

namespace EFCore.DatabaseFirstByScaffold.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public char? Name { get; set; }
        public int? Price { get; set; }
    }
}
