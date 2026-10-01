using CsvHelper;
using ECommerce;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace DesktopApp;

public partial class SaleForm : Form
{
    private readonly string pathClients = "../../../../Datos/clientes.csv";
    private readonly string pathProducts = "../../../../Datos/productos.csv";

    
    public Sale Sale { get; private set; } = new Sale();

    private List<Client> _clients = new();
    private List<IProduct> _products = new();

    public SaleForm()
    {
        InitializeComponent();
        LoadClients();
        LoadProducts();
    }

    private void LoadClients()
    {
        if (File.Exists(pathClients))
        {
            using var reader = new StreamReader(pathClients);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            _clients = csv.GetRecords<Client>().ToList();
        }

        clientList.DataSource = _clients;
        clientList.DisplayMember = "Name";
    }
   


    private void LoadProducts()
    {
        if (File.Exists(pathProducts))
        {
            using var reader = new StreamReader(pathProducts);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            _products = csv.GetRecords<IProduct>().ToList();
        }

        itemsList.DataSource = _products;
        itemsList.DisplayMember = "Name";
    }

    private void AddProduct(object sender, EventArgs e)
    {
        if (productList.SelectedItem is not IProduct product)
        {
            MessageBox.Show("Seleccione un producto.", "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        int quantity = (int)quantityOptions.Value;

      
        int alreadyAdded = Sale.PurchasedItems
            .Where(d => d.ProductName == product.Name)
            .Sum(d => d.Quantity);

        
        if (product is Physical physical && alreadyAdded + quantity > physical.Stock)
        {
            MessageBox.Show(
                $"No hay stock suficiente de '{physical.Name}'. Disponible: {physical.Stock - alreadyAdded}.",
                "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Sale.AddProduct(product, quantity);
        RefreshItems();
    }




    private void RefreshItems()
    {
        string[] lines = Sale.PurchasedItems
            .Select(d => $"{d.ProductName} x{d.Quantity} = {d.Subtotal}").ToArray();

        itemsList.Items.Clear();
        itemsList.Items.AddRange(lines);

        totalLabel.Text = $"Total: {Sale.Total}";
    }




    private void SaveSale(object sender, EventArgs e)
    {
        if (clientList.SelectedItem is not Client client)
        {
            MessageBox.Show("Seleccione un cliente.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (Sale.PurchasedItems.Count == 0)
        {
            MessageBox.Show("La venta no tiene productos.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Sale.DocClient = client.Document;
        Sale.Date = DateTime.Now;

        DialogResult = DialogResult.OK;
        Close();
    }

    private void SaleForm_Load(object sender, EventArgs e)
    {

    }
}