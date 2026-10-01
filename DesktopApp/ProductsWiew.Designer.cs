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
            removeBtn = new Button();
            editBtn = new Button();
            creationBtn = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe Script", 20F);
            title.Location = new Point(341, 71);
            title.Name = "title";
            title.Size = new Size(322, 42);
            title.TabIndex = 1;
            title.Text = "Gestión de Productos";
            // 
            // listView1
            // 
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(36, 242);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(941, 211);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // removeBtn
            // 
            removeBtn.Cursor = Cursors.Hand;
            removeBtn.Location = new Point(901, 210);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new Size(75, 26);
            removeBtn.TabIndex = 3;
            removeBtn.Text = "Eliminar";
            removeBtn.UseVisualStyleBackColor = true;
            removeBtn.Click += RemoveProduct;
            // 
            // editBtn
            // 
            editBtn.Cursor = Cursors.Hand;
            editBtn.Location = new Point(820, 210);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 26);
            editBtn.TabIndex = 4;
            editBtn.Text = "Editar";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += EditProduct;
            // 
            // creationBtn
            // 
            creationBtn.Cursor = Cursors.Hand;
            creationBtn.Location = new Point(669, 210);
            creationBtn.Name = "creationBtn";
            creationBtn.Size = new Size(145, 26);
            creationBtn.TabIndex = 5;
            creationBtn.Text = "Crear Fisico";
            creationBtn.UseVisualStyleBackColor = true;
            creationBtn.Click += CreateProductPhysical;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(507, 210);
            button1.Name = "button1";
            button1.Size = new Size(156, 26);
            button1.TabIndex = 8;
            button1.Text = "Crear Digital";
            button1.UseVisualStyleBackColor = true;
            button1.Click += CreateProductDigital;
            // 
            // ProductsWiew
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 532);
            Controls.Add(button1);
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
        private Button removeBtn;
        private Button editBtn;
        private Button creationBtn;
        private Button button1;
    }
}