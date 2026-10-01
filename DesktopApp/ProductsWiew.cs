using CsvHelper;
using CsvHelper.Configuration;
using ECommerce;

using System.Globalization;


namespace DesktopApp
{
    public partial class ProductsWiew : Form
    {
        private readonly string pathCsv = "../../../../Datos/products.csv";
        private List<IProduct> _products = new();

        public ProductsWiew()
        {

            InitializeComponent();
            ConfigListView();
            LoadDataCsv();
        }
        private void ConfigListView()
        {
            // Reglas de visualización obligatorias para la grilla[cite: 1]
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.HideSelection = false;
            listView1.GridLines = true;
            listView1.MultiSelect = false;

            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Tipo", 70);
            listView1.Columns.Add("Nombre", 150);
            listView1.Columns.Add("Precio", 90);
            listView1.Columns.Add("Categoría", 100);
            listView1.Columns.Add("Peso/Tam.", 80);
            listView1.Columns.Add("Stock", 60);
            listView1.Columns.Add("Costo Envío", 90);
            listView1.Columns.Add("Formato", 70);
            listView1.Columns.Add("URL", 180);
        }
        private void LoadDataCsv()
        {
            if (!File.Exists(pathCsv)) return;

            // Configuramos CsvHelper para ignorar las columnas que falten en el archivo
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using var reader = new StreamReader(pathCsv);
            using var csv = new CsvReader(reader, config);

            var records = new List<IProduct>();
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                if (csv.TryGetField<int>("Stock", out _))
                {
                    records.Add(csv.GetRecord<Physical>());
                }
                else
                {
                    records.Add(csv.GetRecord<Digital>());
                }
            }

            _products = records;
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

    }
    public class ProductCsv
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Weight { get; set; }

        public int? Stock { get; set; }
        public decimal? ShippingCost { get; set; }
    }
}
