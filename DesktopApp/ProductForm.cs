using System;
using System.Windows.Forms;
using ECommerce;

namespace DesktopApp
{
    public partial class ProductForm : Form
    {
        public Physical Product { get; private set; }

        public ProductForm(Physical? product = null)
        {
            InitializeComponent();

            if (product != null)
            {
                Text = "Editar Producto";
                titleLabel.Text = "Editar Producto";
                Product = product;
                nameTxt.Text = product.Name;
                priceInput.Value = product.Price;
                stockInput.Value = product.Stock;
            }
            else
            {
                Text = "Crear Producto";
                titleLabel.Text = "Nuevo Producto";
                Product = new Physical();
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTxt.Text))
            {
                MessageBox.Show(
                    "El nombre del producto es obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                nameTxt.Focus();
                return;
            }

            Product = new Physical
            {
                Name = nameTxt.Text.Trim(),
                Price = priceInput.Value,
                Stock = (int)stockInput.Value
            };

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
