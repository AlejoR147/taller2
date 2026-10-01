namespace DesktopApp
{
    partial class ProducFormDigital
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
            idInput = new NumericUpDown();
            idText = new Label();
            nameInput = new TextBox();
            categoryInput = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label1 = new Label();
            weightInput = new NumericUpDown();
            label2 = new Label();
            desciptionInput = new TextBox();
            label3 = new Label();
            cancelBtn = new Button();
            saveBtn = new Button();
            stockLabel = new Label();
            priceInput = new NumericUpDown();
            priceLabel = new Label();
            titleLabel = new Label();
            urlInput = new TextBox();
            formatInput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)idInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)weightInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            SuspendLayout();
            // 
            // idInput
            // 
            idInput.Location = new Point(151, 79);
            idInput.Name = "idInput";
            idInput.Size = new Size(200, 25);
            idInput.TabIndex = 42;
            // 
            // idText
            // 
            idText.AutoSize = true;
            idText.Location = new Point(62, 87);
            idText.Name = "idText";
            idText.Size = new Size(22, 17);
            idText.TabIndex = 41;
            idText.Text = "Id:";
            // 
            // nameInput
            // 
            nameInput.Location = new Point(151, 125);
            nameInput.Name = "nameInput";
            nameInput.Size = new Size(200, 25);
            nameInput.TabIndex = 39;
            // 
            // categoryInput
            // 
            categoryInput.Location = new Point(151, 265);
            categoryInput.Name = "categoryInput";
            categoryInput.Size = new Size(200, 25);
            categoryInput.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 419);
            label4.Name = "label4";
            label4.Size = new Size(25, 17);
            label4.TabIndex = 37;
            label4.Text = "Url";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(62, 368);
            label5.Name = "label5";
            label5.Size = new Size(57, 17);
            label5.TabIndex = 35;
            label5.Text = "Formato";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 316);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.TabIndex = 34;
            label1.Text = "Peso";
            // 
            // weightInput
            // 
            weightInput.DecimalPlaces = 2;
            weightInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            weightInput.Location = new Point(151, 314);
            weightInput.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            weightInput.Name = "weightInput";
            weightInput.Size = new Size(200, 25);
            weightInput.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 265);
            label2.Name = "label2";
            label2.Size = new Size(65, 17);
            label2.TabIndex = 32;
            label2.Text = "Categoria";
            // 
            // desciptionInput
            // 
            desciptionInput.Location = new Point(151, 220);
            desciptionInput.Name = "desciptionInput";
            desciptionInput.Size = new Size(200, 25);
            desciptionInput.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 223);
            label3.Name = "label3";
            label3.Size = new Size(76, 17);
            label3.TabIndex = 30;
            label3.Text = "Descripcion";
            // 
            // cancelBtn
            // 
            cancelBtn.Cursor = Cursors.Hand;
            cancelBtn.Location = new Point(201, 479);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(90, 34);
            cancelBtn.TabIndex = 29;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += OnCancelClick;
            // 
            // saveBtn
            // 
            saveBtn.Cursor = Cursors.Hand;
            saveBtn.Location = new Point(91, 479);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(90, 34);
            saveBtn.TabIndex = 28;
            saveBtn.Text = "Guardar";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += OnSaveClick;
            // 
            // stockLabel
            // 
            stockLabel.AutoSize = true;
            stockLabel.Location = new Point(62, 179);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(44, 17);
            stockLabel.TabIndex = 27;
            stockLabel.Text = "Precio";
            // 
            // priceInput
            // 
            priceInput.DecimalPlaces = 2;
            priceInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            priceInput.Location = new Point(151, 177);
            priceInput.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(200, 25);
            priceInput.TabIndex = 26;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(62, 128);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(60, 17);
            priceLabel.TabIndex = 25;
            priceLabel.Text = "Nombre:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe Script", 16F);
            titleLabel.Location = new Point(103, 21);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(198, 35);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Nuevo Producto";
            // 
            // urlInput
            // 
            urlInput.Location = new Point(151, 411);
            urlInput.Name = "urlInput";
            urlInput.Size = new Size(200, 25);
            urlInput.TabIndex = 45;
            // 
            // formatInput
            // 
            formatInput.Location = new Point(151, 366);
            formatInput.Name = "formatInput";
            formatInput.Size = new Size(200, 25);
            formatInput.TabIndex = 44;
            // 
            // ProducFormDigital
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 529);
            Controls.Add(urlInput);
            Controls.Add(formatInput);
            Controls.Add(titleLabel);
            Controls.Add(idInput);
            Controls.Add(idText);
            Controls.Add(nameInput);
            Controls.Add(categoryInput);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(weightInput);
            Controls.Add(label2);
            Controls.Add(desciptionInput);
            Controls.Add(label3);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(stockLabel);
            Controls.Add(priceInput);
            Controls.Add(priceLabel);
            Name = "ProducFormDigital";
            Text = "ProducFormDigital";
            ((System.ComponentModel.ISupportInitialize)idInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)weightInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown idInput;
        private Label idText;
        private TextBox nameInput;
        private TextBox categoryInput;
        private Label label4;
        private Label label5;
        private Label label1;
        private NumericUpDown weightInput;
        private Label label2;
        private TextBox desciptionInput;
        private Label label3;
        private Button cancelBtn;
        private Button saveBtn;
        private Label stockLabel;
        private NumericUpDown priceInput;
        private Label priceLabel;
        private Label titleLabel;
        private TextBox urlInput;
        private TextBox formatInput;
    }
}