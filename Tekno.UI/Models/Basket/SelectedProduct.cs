using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tekno.UI.Models.Basket
{
    public class SelectedProduct
    {
        public SelectedProduct()
        {
            Quantity = 1;
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short? Quantity { get; set; }
        public decimal? SubTotal
        {
            get { return Price * Quantity; }

        }
    }
}