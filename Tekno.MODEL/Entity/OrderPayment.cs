using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Entity;

namespace Tekno.MODEL.Entity
{
    public class OrderPayment : CoreEntity
    {
        public int OrderID { get; set; }
        public _OrderType OrderType { get; set; }
        public decimal Price { get; set; }
        public string Bank { get; set; }

    }

    public enum _OrderType
    {
        Transfer = 0,
        CreditCard = 1
    }


}
