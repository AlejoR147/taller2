namespace DesktopApp
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            title = new Label();
            productsBtn = new Button();
            clientsBtn = new Button();
            salesBtn = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe Script", 20F);
            title.Location = new Point(247, 105);
            title.Name = "title";
            title.Size = new Size(277, 42);
            title.TabIndex = 0;
            title.Text = "Menu de opciones";
            // 
            // productsBtn
            // 
            productsBtn.Location = new Point(302, 205);
            productsBtn.Name = "productsBtn";
            productsBtn.Size = new Size(133, 37);
            productsBtn.TabIndex = 1;
            productsBtn.Text = "Gestionar productos";
            productsBtn.UseVisualStyleBackColor = true;
            productsBtn.Click += GoToProducts;
            // 
            // clientsBtn
            // 
            clientsBtn.Location = new Point(302, 267);
            clientsBtn.Name = "clientsBtn";
            clientsBtn.Size = new Size(133, 37);
            clientsBtn.TabIndex = 2;
            clientsBtn.Text = "Gestionar clientes";
            clientsBtn.UseVisualStyleBackColor = true;
            clientsBtn.Click += GoToClients;
            // 
            // salesBtn
            // 
            salesBtn.Location = new Point(302, 334);
            salesBtn.Name = "salesBtn";
            salesBtn.Size = new Size(133, 37);
            salesBtn.TabIndex = 3;
            salesBtn.Text = "Gestionar ventas";
            salesBtn.UseVisualStyleBackColor = true;
            salesBtn.Click += GoToSales;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 558);
            Controls.Add(salesBtn);
            Controls.Add(clientsBtn);
            Controls.Add(productsBtn);
            Controls.Add(title);
            Name = "Menu";
            Text = "ECommerce";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Button productsBtn;
        private Button clientsBtn;
        private Button salesBtn;
    }
}
