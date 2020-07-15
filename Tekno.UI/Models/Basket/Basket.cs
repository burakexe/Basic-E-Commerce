using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tekno.UI.Models.Basket
{
    public class Basket
    {
        //Sepet:Seçilen ürünlerin sözlük biçiminde bir arada tutulduğu yer.
        Dictionary<Guid, SelectedProduct> _myBasket = new Dictionary<Guid, SelectedProduct>();

        //AddProduct metodu seçilen ürünü alır ve sepete ekler.
        public void AddProduct(SelectedProduct product)
        {
            if (_myBasket.ContainsKey(product.ID))
            {
                _myBasket[product.ID].Quantity += 1;
                return;
            }
            _myBasket.Add(product.ID, product);
        }


        //MyBasket is a read only property that gives all the products.
        public List<SelectedProduct> MyBasket
        {
            get
            {
                return _myBasket.Values.ToList();
            }
        }


    }
}