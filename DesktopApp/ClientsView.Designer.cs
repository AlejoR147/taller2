namespace DesktopApp
{
    partial class ClientsView
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
            title = new Label();
            verClientes = new ListView();
            DeleteBtn = new Button();
            EditBtn = new Button();
            CreateBtn = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe Script", 20F);
            title.Location = new Point(208, 118);
            title.Name = "title";
            title.Size = new Size(292, 42);
            title.TabIndex = 1;
            title.Text = "Gestión de Clientes";
            // 
            // verClientes
            // 
            verClientes.Location = new Point(60, 266);
            verClientes.Name = "verClientes";
            verClientes.Size = new Size(590, 213);
            verClientes.TabIndex = 2;
            verClientes.UseCompatibleStateImageBehavior = false;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Cursor = Cursors.Hand;
            DeleteBtn.Location = new Point(413, 224);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(75, 23);
            DeleteBtn.TabIndex = 3;
            DeleteBtn.Text = "Elliminar";
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += DeleteClient;
            // 
            // EditBtn
            // 
            EditBtn.Cursor = Cursors.Hand;
            EditBtn.Location = new Point(494, 224);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(75, 23);
            EditBtn.TabIndex = 4;
            EditBtn.Text = "Editar";
            EditBtn.UseVisualStyleBackColor = true;
            EditBtn.Click += UpdateClient;
            // 
            // CreateBtn
            // 
            CreateBtn.Cursor = Cursors.Hand;
            CreateBtn.Location = new Point(575, 224);
            CreateBtn.Name = "CreateBtn";
            CreateBtn.Size = new Size(75, 23);
            CreateBtn.TabIndex = 5;
            CreateBtn.Text = "Agregar";
            CreateBtn.UseVisualStyleBackColor = true;
            CreateBtn.Click += CreateClient;
            // 
            // ClientsView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 648);
            Controls.Add(CreateBtn);
            Controls.Add(EditBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(verClientes);
            Controls.Add(title);
            Name = "ClientsView";
            Text = "ECommerce";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private ListView verClientes;
        private Button DeleteBtn;
        private Button EditBtn;
        private Button CreateBtn;
    }
}
