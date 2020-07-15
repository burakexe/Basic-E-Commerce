using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Map;
using Tekno.MODEL.Entity;

namespace Tekno.MODEL.Maps
{
    public class OrderMap : CoreMap<Order>
    {
        public OrderMap()
        {
            HasRequired(x => x.AppUser)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.AppUserID);
        }
    }
}
