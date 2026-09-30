using ECommerce;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class clientForm : Form
    {
        public Client Client { get; private set; }
        private readonly List<Client> _ExistingClients;
        private readonly bool _esEdicion;

        //creacion
        public clientForm(List<Client> ExistingClients)
        {
            InitializeComponent();
            _ExistingClients = ExistingClients;
            _esEdicion = false;

            Text = "Crear Nuevo Cliente";
        }

        //edicion
        public clientForm(Client clientToEdit)
        {
            InitializeComponent();
            _esEdicion = true;
            Text = "Editar Cliente";

            // Cargar los datos del cliente actual en las cajas de texto
            txtDocumento.Text = clientToEdit.Document;
            txtNombre.Text = clientToEdit.Name;
            txtCorreo.Text = clientToEdit.Mail;
            txtTelefono.Text = clientToEdit.Phone;

            
        }

        private void SaveClient(object sender, EventArgs e)
        {
            // 1. Validar que los campos críticos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El documento y el nombre son obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,


                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar regla del taller: El documento no se repite (solo si estamos creando)
            if (!_esEdicion && _ExistingClients.Any(c => c.Document == txtDocumento.Text.Trim()))
            {
                MessageBox.Show(
                    "Ya existe un cliente registrado con este número de documento.",
                    "Error de duplicidad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 3. Construir el objeto Cliente final con lo escrito por el usuario
            Client = new Client
            {
                Document = txtDocumento.Text.Trim(),
                Name = txtNombre.Text.Trim(),
                Mail = txtCorreo.Text.Trim(),
                Phone = txtTelefono.Text.Trim()
            };

            // 4. Retornar confirmación (OK) a la vista principal y cerrar la ventana
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelClient(object sender, EventArgs e)
        {
            // Cancelar la operación sin guardar nada
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
