using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdvancedWeb.Models.DataModel;
using System.Data.Entity;

namespace AdvancedWeb.Areas.Admin.Models.DAO
{
    public class AdminProductDAO
    {
        private static AdminProductDAO _instance;
        private DataReference db = new DataReference();

        public static AdminProductDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new AdminProductDAO();
                return _instance;
            }
        }

        public AdminProductDAO() { }

        public Product GetProductInfo(int? id)
        {
            return db.Products.Find(id) != null ? db.Products.Find(id) : null;
        }

        public List<Product> GetProductToList()
        {
            return db.Products.Include("Category").Include("Promotion").ToList();
        }

        public List<Product> GetProductNoDeleteToList()
        {
            return db.Products.Where(x => x.Deleted.Equals(false)).ToList();
        }

        public void CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void EditProduct(Product p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}