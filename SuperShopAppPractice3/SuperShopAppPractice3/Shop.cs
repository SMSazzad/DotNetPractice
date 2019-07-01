using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShopAppPractice3
{
    class Shop
    {
        public Shop()
        {
            products = new List<Product>();
        }
        public string Name { get; set; }
        public string Address { get; set; }

        private List<Product> products;

        public bool AddProducts(Product product)
        {
            products.Add(product);
            return true;
        }

        public string GetDetails()
        {
            string shopInfo = "Name: " + Name + " Address: " + Address+Environment.NewLine;
            string header = "ProductId \t Quantity" + Environment.NewLine;
            string productDetails = "";
            string message = "";
            foreach(Product product in products)
            {
                productDetails += product.ProductId + " \t " + product.Quantity+Environment.NewLine;
            }
            message = shopInfo + header + productDetails;
            return message;
        }

        public bool ProductExist(string id)
        {
            foreach(Product product in products)
            {
                if (product.ProductId == id)
                {
                    return true;
                }
                    
            }
            return false;
        }

        public void AddQuantity(string id, int quantity)
        {
            foreach (Product product in products)
            {
                if (product.ProductId == id)
                {
                    product.Quantity += quantity ;
                }

            }
        }
       

    }
}
