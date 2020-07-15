using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Entity;

namespace Tekno.MODEL.Entity
{
    public class Category:CoreEntity
    {
        //public int ParentID { get; set; } = 0;
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; } // Bir kategori altında birden fazla alt kategori olabilir.


    }
}
