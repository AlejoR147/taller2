namespace DesktopApp
{
    partial class SaleForm
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
            clientList = new ComboBox();
            label2 = new Label();
            productList = new ComboBox();
            itemsList = new ListBox();
            button1 = new Button();
            AddProductButton = new Button();
            ClientLabel = new Label();
            label1 = new Label();
            totalLabel = new Label();
            label4 = new Label();
            quantityOptions = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)quantityOptions).BeginInit();
            SuspendLayout();
            // 
            // clientList
            // 
            clientList.FormattingEnabled = true;
            clientList.Location = new Point(34, 91);
            clientList.Name = "clientList";
            clientList.Size = new Size(182, 33);
            clientList.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.CadetBlue;
            label2.Font = new Font("Bookman Old Style", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(257, 47);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 2;
            label2.Text = "Producto";
            // 
            // productList
            // 
            productList.FormattingEnabled = true;
            productList.Location = new Point(240, 129);
            productList.Name = "productList";
            productList.Size = new Size(193, 33);
            productList.TabIndex = 3;
            // 
            // itemsList
            // 
            itemsList.FormattingEnabled = true;
            itemsList.Location = new Point(240, 227);
            itemsList.Name = "itemsList";
            itemsList.Size = new Size(242, 179);
            itemsList.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(608, 394);
            button1.Name = "button1";
            button1.Size = new Size(161, 34);
            button1.TabIndex = 7;
            button1.Text = "Guardar venta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveSale;
            // 
            // AddProductButton
            // 
            AddProductButton.Location = new Point(240, 91);
            AddProductButton.Name = "AddProductButton";
            AddProductButton.Size = new Size(193, 34);
            AddProductButton.TabIndex = 8;
            AddProductButton.Text = "Agregar producto";
            AddProductButton.UseVisualStyleBackColor = true;
            AddProductButton.Click += AddProduct;
            // 
            // ClientLabel
            // 
            ClientLabel.AutoSize = true;
            ClientLabel.BackColor = Color.CadetBlue;
            ClientLabel.Font = new Font("Bookman Old Style", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClientLabel.ForeColor = Color.White;
            ClientLabel.Location = new Point(125, 47);
            ClientLabel.Name = "ClientLabel";
            ClientLabel.Size = new Size(73, 24);
            ClientLabel.TabIndex = 10;
            ClientLabel.Text = "Client";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.CadetBlue;
            label1.Font = new Font("Bookman Old Style", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(535, 76);
            label1.Name = "label1";
            label1.Size = new Size(99, 21);
            label1.TabIndex = 11;
            label1.Text = "Cantidad:";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.BackColor = Color.CadetBlue;
            totalLabel.Font = new Font("Bookman Old Style", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalLabel.ForeColor = Color.White;
            totalLabel.Location = new Point(549, 207);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(64, 21);
            totalLabel.TabIndex = 12;
            totalLabel.Text = "Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.CadetBlue;
            label4.Font = new Font("Bookman Old Style", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(240, 179);
            label4.Name = "label4";
            label4.Size = new Size(228, 21);
            label4.TabIndex = 13;
            label4.Text = "Visualice los productos:";
            // 
            // quantityOptions
            // 
            quantityOptions.Location = new Point(535, 100);
            quantityOptions.Name = "quantityOptions";
            quantityOptions.Size = new Size(180, 31);
            quantityOptions.TabIndex = 14;
            // Asegurar que el usuario no pueda seleccionar 0 o valores negativos
            quantityOptions.Minimum = 1;
            quantityOptions.Value = 1;
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(quantityOptions);
            Controls.Add(label4);
            Controls.Add(totalLabel);
            Controls.Add(label1);
            Controls.Add(ClientLabel);
            Controls.Add(AddProductButton);
            Controls.Add(button1);
            Controls.Add(itemsList);
            Controls.Add(productList);
            Controls.Add(label2);
            Controls.Add(clientList);
            Name = "SaleForm";
            Text = "SaleForm";
            Load += SaleForm_Load;
            ((System.ComponentModel.ISupportInitialize)quantityOptions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Cliente;
        private ComboBox clientList;
        private Label label2;
        private ComboBox productList;
        private ListBox itemsList;
        private Button button1;
        private Button AddProductButton;
        private Label ClientLabel;
        private Label label1;
        private Label totalLabel;
        private Label label4;
        private NumericUpDown quantityOptions;
    }
}