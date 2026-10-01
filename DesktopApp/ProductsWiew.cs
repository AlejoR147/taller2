using CsvHelper;
using ECommerce;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class ProductsWiew : Form
    {
        private readonly string pathCsv = "../../../../Datos/products.csv";
        private List<Physical> _products = new();

        public ProductsWiew()
        {
            InitializeComponent();
            LoadDataCsv();
        }

        private void LoadDataCsv()
        {
            if (File.Exists(pathCsv))
            {
                using var reader = new StreamReader(pathCsv);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                _products = csv.GetRecords<Physical>().ToList();
            }
            else
            {
                _products = new List<Physical>
                {
                    new Physical { Id = 1, Name = "Laptop Gamer", Price = 3500.00m, Stock = 10 },
                    new Physical { Id = 2, Name = "Mouse Inalámbrico", Price = 85.50m, Stock = 35 },
                    new Physical { Id = 3, Name = "Teclado Mecánico", Price = 220.00m, Stock = 18 },
                    new Physical { Id = 4, Name = "Monitor 24\" FHD", Price = 650.00m, Stock = 12 },
                    new Physical { Id = 5, Name = "Auriculares Bluetooth", Price = 150.00m, Stock = 25 }
                };
                SaveDataCsv();
            }

            LoadProducts();
        }

        private void SaveDataCsv()
        {
            using var writer = new StreamWriter(pathCsv);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(_products);
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
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0].Tag is not Physical selectedProduct)
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
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0].Tag is not Physical selectedProduct)
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

        private void ProductsWiew_Load(object sender, EventArgs e)
        {

        }
    }
}
