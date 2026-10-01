namespace DesktopApp
{
    partial class ProductFormPhysical
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
            titleLabel = new Label();
            priceLabel = new Label();
            stockLabelp = new Label();
            priceInput = new NumericUpDown();
            saveBtn = new Button();
            cancelBtn = new Button();
            label1 = new Label();
            weightInput = new NumericUpDown();
            label2 = new Label();
            desciptionInput = new TextBox();
            label3 = new Label();
            label4 = new Label();
            shippingCostInput = new NumericUpDown();
            label5 = new Label();
            categoryInput = new TextBox();
            nameInput = new TextBox();
            stocktInput = new NumericUpDown();
            idText = new Label();
            idInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)weightInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shippingCostInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stocktInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)idInput).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe Script", 16F);
            titleLabel.Location = new Point(88, 23);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(198, 35);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Nuevo Producto";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(55, 130);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(60, 17);
            priceLabel.TabIndex = 3;
            priceLabel.Text = "Nombre:";
            // 
            // stockLabelp
            // 
            stockLabelp.AutoSize = true;
            stockLabelp.Location = new Point(55, 181);
            stockLabelp.Name = "stockLabelp";
            stockLabelp.Size = new Size(44, 17);
            stockLabelp.TabIndex = 5;
            stockLabelp.Text = "Precio";
            // 
            // priceInput
            // 
            priceInput.DecimalPlaces = 2;
            priceInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            priceInput.Location = new Point(144, 179);
            priceInput.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(200, 25);
            priceInput.TabIndex = 4;
            // 
            // saveBtn
            // 
            saveBtn.Cursor = Cursors.Hand;
            saveBtn.Location = new Point(88, 477);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(90, 34);
            saveBtn.TabIndex = 7;
            saveBtn.Text = "Guardar";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += OnSaveClick;
            // 
            // cancelBtn
            // 
            cancelBtn.Cursor = Cursors.Hand;
            cancelBtn.Location = new Point(198, 477);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(90, 34);
            cancelBtn.TabIndex = 8;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += OnCancelClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 318);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.TabIndex = 13;
            label1.Text = "Peso";
            // 
            // weightInput
            // 
            weightInput.DecimalPlaces = 2;
            weightInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            weightInput.Location = new Point(144, 316);
            weightInput.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            weightInput.Name = "weightInput";
            weightInput.Size = new Size(200, 25);
            weightInput.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 267);
            label2.Name = "label2";
            label2.Size = new Size(65, 17);
            label2.TabIndex = 11;
            label2.Text = "Categoria";
            // 
            // desciptionInput
            // 
            desciptionInput.Location = new Point(144, 222);
            desciptionInput.Name = "desciptionInput";
            desciptionInput.Size = new Size(200, 25);
            desciptionInput.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 225);
            label3.Name = "label3";
            label3.Size = new Size(76, 17);
            label3.TabIndex = 9;
            label3.Text = "Descripcion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 421);
            label4.Name = "label4";
            label4.Size = new Size(98, 17);
            label4.TabIndex = 17;
            label4.Text = "Precio de Envio";
            // 
            // shippingCostInput
            // 
            shippingCostInput.DecimalPlaces = 2;
            shippingCostInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            shippingCostInput.Location = new Point(144, 419);
            shippingCostInput.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            shippingCostInput.Name = "shippingCostInput";
            shippingCostInput.Size = new Size(200, 25);
            shippingCostInput.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 370);
            label5.Name = "label5";
            label5.Size = new Size(39, 17);
            label5.TabIndex = 15;
            label5.Text = "Stock";
            // 
            // categoryInput
            // 
            categoryInput.Location = new Point(144, 267);
            categoryInput.Name = "categoryInput";
            categoryInput.Size = new Size(200, 25);
            categoryInput.TabIndex = 19;
            // 
            // nameInput
            // 
            nameInput.Location = new Point(144, 127);
            nameInput.Name = "nameInput";
            nameInput.Size = new Size(200, 25);
            nameInput.TabIndex = 20;
            // 
            // stocktInput
            // 
            stocktInput.Location = new Point(144, 368);
            stocktInput.Name = "stocktInput";
            stocktInput.Size = new Size(200, 25);
            stocktInput.TabIndex = 21;
            // 
            // idText
            // 
            idText.AutoSize = true;
            idText.Location = new Point(55, 89);
            idText.Name = "idText";
            idText.Size = new Size(22, 17);
            idText.TabIndex = 22;
            idText.Text = "Id:";
            // 
            // idInput
            // 
            idInput.Location = new Point(144, 81);
            idInput.Name = "idInput";
            idInput.Size = new Size(200, 25);
            idInput.TabIndex = 24;
            // 
            // ProductFormPhysical
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(381, 555);
            Controls.Add(idInput);
            Controls.Add(idText);
            Controls.Add(stocktInput);
            Controls.Add(nameInput);
            Controls.Add(categoryInput);
            Controls.Add(label4);
            Controls.Add(shippingCostInput);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(weightInput);
            Controls.Add(label2);
            Controls.Add(desciptionInput);
            Controls.Add(label3);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(stockLabelp);
            Controls.Add(priceInput);
            Controls.Add(priceLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductFormPhysical";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Producto";
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)weightInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)shippingCostInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)stocktInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)idInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label nameLabel;
        private Label priceLabel;
        private Label stockLabelp;
        private TextBox nameTxt;
        private NumericUpDown priceInput;
        private NumericUpDown stockInput;
        private Button saveBtn;
        private Button cancelBtn;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private NumericUpDown weightInput;
        private Label label2;
        private TextBox desciptionInput;
        private Label label3;
       
        private Label label4;
        private NumericUpDown shippingCostInput;
        private Label label5;
        private TextBox categoryInput;
        private TextBox nameInput;
        private NumericUpDown stocktInput;
        private Label idText;
        private NumericUpDown idInput;
    }
}
