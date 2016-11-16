using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdvancedWeb.Models.DataModel;

namespace AdvancedWeb.Models.Helper
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public String Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public double Total
        {
            get
            {
                return Quantity * Price;
            }
        }

        public ShoppingCart(int productId)
        {
            using (DataReference db = new DataReference())
            {
                this.ProductId = productId;
                Product p = db.Products.Single(x => x.Id == productId);
                this.Name = p.Name;
                this.Image = p.Image;
                this.Price = double.Parse(p.Price.ToString());
                Quantity = 1;
            }
        }
    }
}