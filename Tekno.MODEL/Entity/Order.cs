using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Entity;

namespace Tekno.MODEL.Entity
{
    public class Order:CoreEntity

    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public Guid AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public bool Confirmed { get; set; }

        public decimal TotalProductPrice { get; set; }
        public decimal TotalTaxPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
