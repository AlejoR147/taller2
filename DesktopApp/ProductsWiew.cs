using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ECommerce;

namespace DesktopApp
{
    public partial class ProductsWiew : Form
    {
        private static IEnumerable<Product> _products =
        [
            new Product { Name = "Laptop Gamer", Price = 3500.00m, Stock = 10 },
            new Product { Name = "Mouse Inalámbrico", Price = 85.50m, Stock = 35 },
            new Product { Name = "Teclado Mecánico", Price = 220.00m, Stock = 18 },
            new Product { Name = "Monitor 24\" FHD", Price = 650.00m, Stock = 12 },
            new Product { Name = "Auriculares Bluetooth", Price = 150.00m, Stock = 25 }
        ];

        public ProductsWiew()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            listView1.Items.Clear();

            foreach (var product in _products)
            {
                var item = new ListViewItem(product.Name);
                item.SubItems.Add(product.Price.ToString("C2"));
                item.SubItems.Add(product.Stock.ToString());
                item.Tag = product;

                listView1.Items.Add(item);
            }
        }

        private void CreateProduct(object sender, EventArgs e)
        {
            using var productForm = new ProductForm();
            if (productForm.ShowDialog(this) == DialogResult.OK)
            {
                _products = _products.Append(productForm.Product).ToList();
                LoadProducts();
            }
        }

        private void EditProduct(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0].Tag is not Product selectedProduct)
            {
                MessageBox.Show(
                    "Por favor, seleccione un producto de la lista para editar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var productForm = new ProductForm(selectedProduct);
            if (productForm.ShowDialog(this) == DialogResult.OK)
            {
                _products = _products
                    .Select(p => p == selectedProduct ? productForm.Product : p)
                    .ToList();
                LoadProducts();
            }
        }

        private void RemoveProduct(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0].Tag is not Product selectedProduct)
            {
                MessageBox.Show(
                    "Por favor, seleccione un producto de la lista para eliminar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de eliminar el producto '{selectedProduct.Name}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _products = _products
                    .Where(p => p != selectedProduct)
                    .ToList();
                LoadProducts();
            }
        }
    }
}
