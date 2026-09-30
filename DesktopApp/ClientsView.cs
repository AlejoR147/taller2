using CsvHelper;
using ECommerce;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class ClientsView : Form
    {
        private readonly string rutaCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clientes.csv");
        private List<Cliente> _clientes = new();
        public ClientsView()
        {
            InitializeComponent();
            ConfigListView();
            CargarDatosCsv();
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


        public void LoadClientes(List<Cliente> listaClientes)
        {
            verClientes.Items.Clear();

            foreach (Cliente cliente in listaClientes)
            {
                ListViewItem item = new ListViewItem(cliente.Documento);

                item.SubItems.Add(cliente.Nombre);
                item.SubItems.Add(cliente.Correo);
                item.SubItems.Add(cliente.Telefono);

                verClientes.Items.Add(item);
            }
        }



        
    }
}
