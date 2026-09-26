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
            var productsView = new ProductsWiew();

            Hide();

            productsView.ShowDialog();

            Show();
        }

        private void GoToClients(object sender, EventArgs e)
        {
            var clientsView = new ClientsView();

            Hide();

            clientsView.ShowDialog();

            Show();
        }

        private void GoToSales(object sender, EventArgs e)
        {
            var salesView = new SalesView();

            Hide();

            salesView.ShowDialog();

            Show();
        }
    }
}
