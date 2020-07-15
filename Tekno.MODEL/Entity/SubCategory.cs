using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Entity;

namespace Tekno.MODEL.Entity
{
    public class SubCategory:CoreEntity
    {
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public virtual List<Product> Products { get; set; } // Bir alt kategoride birden fazla ürün eklenebilir.
    }
}
