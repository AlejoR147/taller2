using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using CsvHelper;
using ECommerce;

namespace DesktopApp;

public partial class SalesView : Form
{
        private readonly string pathCsv = "../../../../Datos/ventas.csv";
        private readonly string pathFisicos = "../../../../Datos/productos.csv"; 
        private List<Sale> _sales = new();
        private readonly string pathDetails = "../../../../Datos/detalles_venta.csv";
        private class DetailCsv
        {
            public int SaleId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public string ProductDescrip { get; set; } = string.Empty;
            public decimal ProductPrice { get; set; }
            public int Quantity { get; set; }
        }

        public SalesView()
        {
            InitializeComponent();
            ConfigListView();
            LoadDataCsv();
        }

        private void ConfigListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;

            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 70);
            listView1.Columns.Add("Fecha", 120);
            listView1.Columns.Add("Cliente", 100);
            listView1.Columns.Add("Productos", 250); // Más ancha porque aquí va el string concatenado
            listView1.Columns.Add("Total", 90);
        }

        private void LoadDataCsv()
        {
            if (File.Exists(pathCsv))
            {
                using var reader = new StreamReader(pathCsv);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                _sales = csv.GetRecords<Sale>().ToList();
            }
            // Cargar detalles asociados (si existen)
            LoadDetailsCsv();

            LoadSales();
        }

        private void SaveDataCsv()
        {
            using var writer = new StreamWriter(pathCsv);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(_sales);
        }

        public void LoadSales()
        {
            listView1.Items.Clear();

            foreach (var sale in _sales)
            {
                ListViewItem item = new ListViewItem(sale.Id.ToString());

                item.SubItems.Add(sale.Date.ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(sale.DocClient);
                item.SubItems.Add(sale.Products); // Carga tu texto concatenado perfectamente
                item.SubItems.Add(sale.Total.ToString("C2"));

                item.Tag = sale;
                listView1.Items.Add(item);
            }
        }

        private void CreateSale(object sender, EventArgs e)
        {
            using var saleForm = new SaleForm();
            if (saleForm.ShowDialog(this) == DialogResult.OK)
            {
                // Inmutabilidad
                _sales = _sales.Append(saleForm.Sale).ToList();

                // 1. Guardar la venta en su único CSV
                SaveDataCsv();

                // 2. Descontar el stock real
                DescontarStock(saleForm.Sale);
                // Guardar detalles de la venta en CSV separado
                SaveDetailsCsv();

                LoadSales();
            }
        }

        // Guardar todos los SaleDetail de todas las ventas en un CSV separado
        private void SaveDetailsCsv()
        {
            try
            {
                var allDetails = new List<DetailCsv>();
                foreach (var s in _sales)
                {
                    foreach (var d in s.PurchasedItems)
                    {
                        allDetails.Add(new DetailCsv
                        {
                            SaleId = s.Id,
                            ProductName = d.ProductName,
                            ProductDescrip = d.ProductDescrip,
                            ProductPrice = d.ProductPrice,
                            Quantity = d.Quantity
                        });
                    }
                }

                using var writer = new StreamWriter(pathDetails, append: false);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(allDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando detalles de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar detalles desde CSV y asociarlos a cada Sale en memoria
        private void LoadDetailsCsv()
        {
            if (!File.Exists(pathDetails)) return;

            try
            {
                using var reader = new StreamReader(pathDetails);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var details = csv.GetRecords<DetailCsv>().ToList();

                foreach (var s in _sales)
                {
                    var relacionados = details.Where(d => d.SaleId == s.Id).ToList();
                    s.PurchasedItems = relacionados.Select(d => new SaleDetail(d.ProductName, d.ProductDescrip, d.ProductPrice, d.Quantity)).ToList();
                    s.Total = s.PurchasedItems.Sum(p => p.Subtotal);
                    s.Products = string.Join(", ", s.PurchasedItems.Select(p => $"{p.ProductName} x{p.Quantity}"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error leyendo detalles de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar venta seleccionada
        private void RemoveSale(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0].Tag is not Sale selectedSale)
            {
                MessageBox.Show("Seleccione una venta para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"¿Está seguro de eliminar la venta {selectedSale.Id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _sales = _sales.Where(s => s.Id != selectedSale.Id).ToList();
                SaveDataCsv();
                SaveDetailsCsv();
                LoadSales();
            }
        }

        // Editar venta: abrir SaleForm con la venta seleccionada y reemplazarla si se guarda
        private void EditSale(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0].Tag is not Sale selectedSale)
            {
                MessageBox.Show("Seleccione una venta para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var form = new SaleForm(selectedSale);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _sales = _sales.Select(s => s.Id == selectedSale.Id ? form.Sale : s).ToList();
                SaveDataCsv();
                SaveDetailsCsv();
                LoadSales();
            }
        }

        // Método vital de regla de negocio: Descontar stock
        private void DescontarStock(Sale nuevaVenta)
        {
            if (!File.Exists(pathFisicos)) return;

            using var reader = new StreamReader(pathFisicos);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var productosFisicos = csv.GetRecords<Physical>().ToList();

            bool stockActualizado = false;

            // Revisamos cada producto comprado en esta venta
            foreach (var detalle in nuevaVenta.PurchasedItems)
            {
                var productoEnBase = productosFisicos.FirstOrDefault(p => p.Name == detalle.ProductName);
                if (productoEnBase != null)
                {
                    productoEnBase.Stock -= detalle.Quantity;
                    stockActualizado = true;
                }
            }

            // Si se vendió algún producto físico, guardamos el CSV de productos actualizado
            if (stockActualizado)
            {
                using var writer = new StreamWriter(pathFisicos);
                using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(productosFisicos);
            }
        }

        private void SalesView_Load(object sender, EventArgs e)
        {
        }
    }

