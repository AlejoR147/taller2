using ECommerce;

namespace DesktopApp
{
    public partial class ProducFormDigital : Form
    {

        public Digital Product { get; private set; }

        private readonly bool _esEdicion;
        private readonly int _originalId;

        //crear
        public ProducFormDigital()
        {
            InitializeComponent();
            _esEdicion = false;

            Text = "Crear Producto Físico";
            titleLabel.Text = "Nuevo Producto";

            if (idInput != null) idInput.Enabled = false;
        }

        // editar
        public ProducFormDigital(Digital productToEdit)
        {
            InitializeComponent();
            _esEdicion = true;
            _originalId = productToEdit.Id;

            Text = "Editar Producto";
            titleLabel.Text = "Editar Producto";

            idInput.Value = productToEdit.Id;
            idInput.Enabled = false;
            nameInput.Text = productToEdit.Name;
            priceInput.Value = (decimal)productToEdit.Price;
            desciptionInput.Text = productToEdit.Description;
            categoryInput.Text = productToEdit.Category;
            weightInput.Value = (decimal)productToEdit.Weight;
            formatInput.Text = productToEdit.Format;
            urlInput.Text = productToEdit.Url;
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameInput.Text))
            {
                MessageBox.Show(
                    "El nombre del producto es obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                nameInput.Focus();
                return;
            }

            Product = new Digital
            {
                Name = nameInput.Text.Trim(),
                Description = desciptionInput.Text.Trim(),
                Price = (decimal)priceInput.Value,
                Category = categoryInput.Text.Trim(),
                Weight = (decimal)weightInput.Value,
                Format = formatInput.Text.Trim(),
                Url = urlInput.Text.Trim(),
            };


            if (_esEdicion)
            {
                Product.Id = _originalId;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}

