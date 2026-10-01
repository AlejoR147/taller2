using CsvHelper;
using ECommerce;
using System.Data;
using System.Globalization;

namespace DesktopApp;

public partial class SaleForm : Form
{
    private readonly string pathClients = "../../../../Datos/clientes.csv";
    private readonly string pathProducts = "../../../../Datos/products.csv";

    
    public Sale Sale { get; private set; } = new Sale();

    private List<Client> _clients = new();
    private List<IProduct> _products = new();

    public SaleForm()
    {
        InitializeComponent();
        LoadClients();
        LoadProducts();
    }

    // Constructor para editar una venta existente
    public SaleForm(Sale sale) : this()
    {
        // Reutiliza la inicialización por defecto
        Sale = sale ?? new Sale();

        // Seleccionar cliente asociado si existe
        if (!string.IsNullOrEmpty(Sale.DocClient))
        {
            var matching = _clients.FirstOrDefault(c => c.Document == Sale.DocClient);
            if (matching != null)
                clientList.SelectedItem = matching;
        }

        // Refrescar lista de ítems y total
        RefreshItems();
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
        _products.Clear();

        if (!File.Exists(pathProducts))
        {
            productList.DataSource = null;
            productList.DataSource = _products;
            productList.DisplayMember = "Name";
            return;
        }

        // Detectar separador de columnas (coma o punto y coma) para ser más tolerantes con archivos generados externamente
        string delimiter = ",";
        try
        {
            var headerLine = File.ReadLines(pathProducts).FirstOrDefault();
            if (!string.IsNullOrEmpty(headerLine))
            {
                int commaCount = headerLine.Count(c => c == ',');
                int semiCount = headerLine.Count(c => c == ';');
                if (semiCount > commaCount) delimiter = ";";
            }
        }
        catch
        {
            // Si hay un problema leyendo el fichero, continuar con el separador por defecto
            delimiter = ",";
        }

        var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = delimiter,
            MissingFieldFound = null,
            BadDataFound = null,
            HeaderValidated = null,
            TrimOptions = CsvHelper.Configuration.TrimOptions.Trim
        };

        var records = new List<ProductCsv>();
        try
        {
            using var reader = new StreamReader(pathProducts);
            using var csv = new CsvReader(reader, config);

            // Leer de forma segura registro a registro para evitar que una fila corrupta rompa la carga completa
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                try
                {
                    var rec = csv.GetRecord<ProductCsv>();
                    records.Add(rec);
                }
                catch (Exception)
                {
                    // Omitir registro erróneo y continuar
                    continue;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error leyendo el CSV de productos ('{pathProducts}'): {ex.Message}", "Error lectura CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        foreach (var record in records)
        {
            IProduct product;

            // Si Stock tiene información → Physical
            if (record.Stock.HasValue)
            {
                product = new Physical
                {
                    Id = record.Id,
                    Name = record.Name,
                    Price = record.Price,
                    Description = record.Description,
                    Category = record.Category,
                    Weight = record.Weight,
                    Stock = record.Stock.Value,
                    ShippingCost = record.ShippingCost ?? 0
                };
            }
            // Si Stock está vacío → Digital
            else
            {
                product = new Digital
                {
                    Id = record.Id,
                    Name = record.Name,
                    Price = record.Price,
                    Description = record.Description,
                    Category = record.Category,
                    Weight = record.Weight
                };
            }

            _products.Add(product);
        }

        productList.DataSource = null;
        productList.DataSource = _products;
        productList.DisplayMember = "Name";
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

        // Validación: la cantidad debe ser mayor que cero
        if (quantity <= 0)
        {
            MessageBox.Show("La cantidad debe ser mayor que cero.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

      
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