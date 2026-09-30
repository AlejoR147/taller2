namespace DesktopApp
{
    partial class clientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtDocumento = new TextBox();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(251, 254);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += SaveClient;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(138, 254);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += CancelClient;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(103, 60);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.PlaceholderText = "Documento";
            txtDocumento.Size = new Size(260, 25);
            txtDocumento.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(103, 108);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(260, 25);
            txtNombre.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(103, 207);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Telefono";
            txtTelefono.Size = new Size(260, 25);
            txtTelefono.TabIndex = 5;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(103, 159);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Correo";
            txtCorreo.Size = new Size(260, 25);
            txtCorreo.TabIndex = 4;
            // 
            // clientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 344);
            Controls.Add(txtTelefono);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
            Controls.Add(txtDocumento);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Name = "clientForm";
            Text = "Gestión de Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtDocumento;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
    }
}