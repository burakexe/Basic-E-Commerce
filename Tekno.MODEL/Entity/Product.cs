using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tekno.CORE.Entity;

namespace Tekno.MODEL.Entity
{
    public class Product : CoreEntity
    {
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Required(ErrorMessage = "Fiyat boş geçilemez!")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Stok boş geçilemez!")]
        public short? UnitsInStock { get; set; }

        public int CateogryID { get; set; }
        public Category Category { get; set; }
        public Guid SubCategoryID { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; }
    }
}