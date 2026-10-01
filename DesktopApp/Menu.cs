namespace DesktopApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void GoToProducts(object sender, EventArgs e)
        {
            Hide();
            try
            {
                using var productsView = new ProductsWiew();
                productsView.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Gestión de Productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Show();
            }
        }

        private void GoToClients(object sender, EventArgs e)
        {
            Hide();
            try
            {
                using var clientsView = new ClientsView();
                clientsView.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Gestión de Clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Show();
            }
        }

        private void GoToSales(object sender, EventArgs e)
        {
            Hide();
            try
            {
                using var salesView = new SalesView();
                salesView.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Gestión de Ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Show();
            }
        }
    }
}
