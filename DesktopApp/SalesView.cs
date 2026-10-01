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
        listView1.Columns.Add("Fecha", 120);
        listView1.Columns.Add("Cliente", 100);
        listView1.Columns.Add("Productos", 160);
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
            ListViewItem item = new ListViewItem(sale.Date.ToString("dd/MM/yyyy HH:mm"));

            item.SubItems.Add(sale.DocClient);
            item.SubItems.Add(sale.Products);
            item.SubItems.Add(sale.Total.ToString("C2"));

            item.Tag = sale;

            listView1.Items.Add(item);
        }
    }

    private void CreateSale(object sender, EventArgs e)
    {
        // Venta de prueba mientras no exista el SaleForm
        var sale = new Sale("1025654083");
        sale.AddProduct(new Physical { Name = "Teclado", Price = 220 }, 2);
        sale.AddProduct(new Physical { Name = "Mouse", Price = 85.5m }, 1);

        _sales = _sales.Append(sale).ToList();
        SaveDataCsv();
        LoadSales();
    }

    private void SalesView_Load(object sender, EventArgs e)
    {

    }
}
}
