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

