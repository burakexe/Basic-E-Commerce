using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Map;
using Tekno.MODEL.Entity;

namespace Tekno.MODEL.Maps
{
    public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            HasMany(x => x.Products) // Bir alt kategoride birden fazla ürün olabilir - ex: klavyeler altında bir sürü ürün.
                .WithRequired(x => x.SubCategory)
                .HasForeignKey(x => x.SubCategoryID);
        }
    }
}
