using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Map;
using Tekno.MODEL.Entity;

namespace Tekno.MODEL.Maps
{
    public class ProductMap : CoreMap<Product>
    {
        public ProductMap()
        {
            HasRequired(x => x.SubCategory).WithMany(x => x.Products).HasForeignKey(x => x.SubCategoryID);
            // Bir ürünün bir alt kategorisi olur
        }
    }
}
