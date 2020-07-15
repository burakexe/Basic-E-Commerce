using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Map;
using Tekno.MODEL.Entity;

namespace Tekno.MODEL.Maps
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            HasMany(x => x.SubCategories)
               .WithRequired(x => x.Category).HasForeignKey(x => x.CategoryID);
        }

    }
}
