using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopAppPractice3
{
    public partial class SuperShopUi : Form
    {
        public SuperShopUi()
        {
            InitializeComponent();
        }

        Shop shop;
        private void ShopSaveButton_Click(object sender, EventArgs e)
        {
            shop = new Shop();
            shop.Name = nameTextBox.Text;
            shop.Address = addressTextBox.Text;
            MessageBox.Show("Saved!");
        }

        private void ProductSaveButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductId = itemTextBox.Text;
            product.Quantity = Convert.ToInt32(quantityTextBox.Text);

            if (!shop.ProductExist(itemTextBox.Text))
            {
                shop.AddProducts(product);
                MessageBox.Show("product saved");
            }

            else
                shop.AddQuantity(itemTextBox.Text, Convert.ToInt32(quantityTextBox.Text));

           
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            string message = shop.GetDetails();
            MessageBox.Show(message);
        }
    }
}
