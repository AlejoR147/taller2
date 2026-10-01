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
            //Filtrar las listas en memoria según su tipo concreto
            var fisicos = _products.OfType<Physical>().ToList();
            var digitales = _products.OfType<Digital>().ToList();

            //Guardar los productos Físicos 
            using (var writer = new StreamWriter(pathCsv, append: false))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(fisicos);
            }

            //Agregar los productos Digitales 
            if (digitales.Count > 0)
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };

                using var writer = new StreamWriter(pathCsv, append: true);
                using var csv = new CsvWriter(writer, config);

                csv.WriteRecords(digitales);
            }
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
                var item = new ListViewItem(product.Id.ToString());

                // Identificamos el tipo para mostrarlo en la columna
                item.SubItems.Add(product is Physical ? "Físico" : "Digital");

                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.Price.ToString("C2"));
                item.SubItems.Add(product.Category);
                item.SubItems.Add(product.Weight.ToString("N2"));

                // extraer las propiedades exclusivas 
                if (product is Physical phys)
                {
                    item.SubItems.Add(phys.Stock.ToString());
                    item.SubItems.Add(phys.ShippingCost.ToString("C2"));
                    item.SubItems.Add("-"); 
                    item.SubItems.Add("-"); 
                }
                else if (product is Digital dig)
                {
                    item.SubItems.Add("-"); 
                    item.SubItems.Add("-");
                    item.SubItems.Add(dig.Format);
                    item.SubItems.Add(dig.Url);
                }

                item.Tag = product;
                listView1.Items.Add(item);
            }
        }

        private void CreateProductPhysical(object sender, EventArgs e)
        {
            using var productForm = new ProductFormPhysical();
            if (productForm.ShowDialog(this) == DialogResult.OK)
            {
                _products = _products.Append(productForm.Product).ToList();
                SaveDataCsv();
                LoadProducts();
            }
        }
        private void CreateProductDigital(object sender, EventArgs e)
        {
            using var productForm = new ProducFormDigital();
            if (productForm.ShowDialog(this) == DialogResult.OK)
            {
                _products = _products.Append(productForm.Product).ToList();
                SaveDataCsv();
                LoadProducts();
            }
        }

        private void EditProduct(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0].Tag is not IProduct selectedProduct)
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedProduct is Physical physicalToEdit)
            {
                using var form = new ProductFormPhysical(physicalToEdit);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    _products = _products.Select(p => p.Id == physicalToEdit.Id ? form.Product : p).ToList();
                    SaveDataCsv();
                    LoadProducts();
                }
            }
            else if (selectedProduct is Digital digitalToEdit)
            {
                using var form = new ProducFormDigital(digitalToEdit);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    _products = _products.Select(p => p.Id == digitalToEdit.Id ? form.Product : p).ToList();
                    SaveDataCsv();
                    LoadProducts();
                }
            }
        }

        private void RemoveProduct(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0].Tag is not IProduct selectedProduct)
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de eliminar el producto '{selectedProduct.Name}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _products = _products.Where(p => p.Id != selectedProduct.Id).ToList();
                SaveDataCsv();
                LoadProducts();
            }
        }

        private void ProductsWiew_Load(object sender, EventArgs e)
        {

        }
    }
}
