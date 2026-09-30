using CsvHelper;
using ECommerce;
using System.Globalization;

namespace DesktopApp
{
    public partial class ClientsView : Form
    {
        private const string pathCsv = "../../../../Datos/clientes.csv";
        private List<Client> _clients = new();

        public ClientsView()
        {
            InitializeComponent();
            ConfigListView();
            LoadDataCsv();
        }

        private void ConfigListView()
        {
            verClientes.View = View.Details;
            verClientes.FullRowSelect = true;
            verClientes.GridLines = true;
            verClientes.MultiSelect = false;
            verClientes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            verClientes.Columns.Clear();

            verClientes.Columns.Add("Documento", 100);
            verClientes.Columns.Add("Nombre", 200);
            verClientes.Columns.Add("Correo", 180);
            verClientes.Columns.Add("Teléfono", 100);
        }

        private void LoadDataCsv()
        {
            if (File.Exists(pathCsv))
            {
                using var reader = new StreamReader(pathCsv);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                _clients = csv.GetRecords<Client>().ToList();
            }
            LoadClients();
        }

        private void SaveDataCsv()
        {
            using var writer = new StreamWriter(pathCsv);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(_clients);
        }

        public void LoadClients()
        {
            verClientes.Items.Clear();

            foreach (var cliente in _clients)
            {
                ListViewItem item = new ListViewItem(cliente.Document);

                item.SubItems.Add(cliente.Name);
                item.SubItems.Add(cliente.Mail);
                item.SubItems.Add(cliente.Phone);

                item.Tag = cliente;

                verClientes.Items.Add(item);
            }
        }
        private void CreateClient(object sender, EventArgs e)
        {
            using var clientForm = new clientForm(_clients);

            if (clientForm.ShowDialog(this) == DialogResult.OK)
            {
                _clients = _clients.Append(clientForm.Client).ToList();
                SaveDataCsv();
                LoadClients();
            }
        }

        private void UpdateClient(object sender, EventArgs e)
        {
            if (verClientes.SelectedItems.Count == 0 || verClientes.SelectedItems[0].Tag is not Client selectedClient)
            {
                MessageBox.Show(
                    "Por favor, seleccione un cliente de la lista para editar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var clientForm = new clientForm(selectedClient);

            if (clientForm.ShowDialog(this) == DialogResult.OK)
            {
                _clients = _clients
                    .Select(c => c == selectedClient ? clientForm.Client : c)
                    .ToList();

                SaveDataCsv();
                LoadClients();
            }
        }

        private void DeleteClient(object sender, EventArgs e)
        {
            if (verClientes.SelectedItems.Count == 0 || verClientes.SelectedItems[0].Tag is not Client selectedClient)
            {
                MessageBox.Show(
                    "Por favor, seleccione un cliente de la lista para eliminar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de eliminar el cliente '{selectedClient.Name}' con documento {selectedClient.Document}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // El taller exige preguntar: ¿se puede eliminar un cliente que ya compró?
                // Aquí deberás validar si el documento existe en las ventas antes de ejecutar el .Where()

                _clients = _clients
                    .Where(c => c != selectedClient)
                    .ToList();

                SaveDataCsv();
                LoadClients();
            }
        }
    }
}
