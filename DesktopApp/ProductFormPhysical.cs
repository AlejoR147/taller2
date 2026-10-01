using System;
using System.Windows.Forms;
using ECommerce;

namespace DesktopApp
{
    public partial class ProductFormPhysical : Form
    {
        public Physical Product { get; private set; }
        private readonly bool _esEdicion;
        private readonly int _originalId;  
        public ProductFormPhysical(Physical? product = null)
        {
            InitializeComponent();

            if (product != null)
            {
                _esEdicion = true;
                _originalId = product.Id;

                Text = "Editar Producto Físico";
                titleLabel.Text = "Editar Producto";

                if (idInput != null)
                {
                    idInput.Value = product.Id;
                    idInput.Enabled = false;
                }
                
                nameInput.Text = product.Name;
                priceInput.Value = (decimal)product.Price;
                desciptionInput.Text = product.Description;
                categoryInput.Text = product.Category;
                weightInput.Value = (decimal)product.Weight;
                stocktInput.Value = product.Stock;
                shippingCostInput.Value = product.ShippingCost;
            }
            else
            { 
                _esEdicion = false;

                Text = "Crear Producto Físico";
                titleLabel.Text = "Nuevo Producto";

                if (idInput != null) idInput.Enabled = false;
            }
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

            Product = new Physical
            {
                Name = nameInput.Text.Trim(),
                Description = desciptionInput.Text.Trim(),
                Price = (decimal)priceInput.Value,
                Category = categoryInput.Text.Trim(),
                Weight = (decimal)weightInput.Value, 
                Stock = (int)stocktInput.Value,
                ShippingCost = shippingCostInput.Value
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