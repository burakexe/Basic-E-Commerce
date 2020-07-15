using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Entity;

namespace Tekno.MODEL.Entity
{
    public class OrderDetail:CoreEntity

    {
        public short? Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal? Price { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
