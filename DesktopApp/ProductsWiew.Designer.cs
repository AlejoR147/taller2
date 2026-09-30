namespace DesktopApp
{
    partial class ProductsWiew
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
            listView1 = new ListView();
            nameColumn = new ColumnHeader();
            priceColumn = new ColumnHeader();
            stockColumn = new ColumnHeader();
            removeBtn = new Button();
            editBtn = new Button();
            creationBtn = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe Script", 20F);
            title.Location = new Point(215, 105);
            title.Name = "title";
            title.Size = new Size(322, 42);
            title.TabIndex = 1;
            title.Text = "Gestión de Productos";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { nameColumn, priceColumn, stockColumn });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(127, 246);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(471, 211);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // nameColumn
            // 
            nameColumn.Text = "Nombre";
            nameColumn.Width = 210;
            // 
            // priceColumn
            // 
            priceColumn.Text = "Precio";
            priceColumn.Width = 135;
            // 
            // stockColumn
            // 
            stockColumn.Text = "Stock";
            stockColumn.Width = 120;
            // 
            // removeBtn
            // 
            removeBtn.Location = new Point(523, 213);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new Size(75, 26);
            removeBtn.TabIndex = 3;
            removeBtn.Text = "Eliminar";
            removeBtn.UseVisualStyleBackColor = true;
            removeBtn.Click += RemoveProduct;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(442, 213);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 26);
            editBtn.TabIndex = 4;
            editBtn.Text = "Editar";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += EditProduct;
            // 
            // creationBtn
            // 
            creationBtn.Location = new Point(361, 213);
            creationBtn.Name = "creationBtn";
            creationBtn.Size = new Size(75, 26);
            creationBtn.TabIndex = 5;
            creationBtn.Text = "Crear";
            creationBtn.UseVisualStyleBackColor = true;
            creationBtn.Click += CreateProduct;
            // 
            // ProductsWiew
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 648);
            Controls.Add(creationBtn);
            Controls.Add(editBtn);
            Controls.Add(removeBtn);
            Controls.Add(listView1);
            Controls.Add(title);
            Name = "ProductsWiew";
            Text = "ECommerce";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private ListView listView1;
        private ColumnHeader nameColumn;
        private ColumnHeader priceColumn;
        private ColumnHeader stockColumn;
        private Button removeBtn;
        private Button editBtn;
        private Button creationBtn;
    }
}