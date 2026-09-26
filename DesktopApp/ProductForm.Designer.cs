namespace DesktopApp
{
    partial class ProductForm
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
            nameLabel = new Label();
            priceLabel = new Label();
            stockLabel = new Label();
            nameTxt = new TextBox();
            priceInput = new NumericUpDown();
            stockInput = new NumericUpDown();
            saveBtn = new Button();
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stockInput).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe Script", 16F);
            titleLabel.Location = new Point(85, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(190, 36);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Nuevo Producto";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(40, 80);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(54, 15);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Nombre:";
            // 
            // nameTxt
            // 
            nameTxt.Location = new Point(115, 77);
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(200, 23);
            nameTxt.TabIndex = 2;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(40, 125);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(42, 15);
            priceLabel.TabIndex = 3;
            priceLabel.Text = "Precio:";
            // 
            // priceInput
            // 
            priceInput.DecimalPlaces = 2;
            priceInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            priceInput.Location = new Point(115, 122);
            priceInput.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(200, 23);
            priceInput.TabIndex = 4;
            // 
            // stockLabel
            // 
            stockLabel.AutoSize = true;
            stockLabel.Location = new Point(40, 170);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(39, 15);
            stockLabel.TabIndex = 5;
            stockLabel.Text = "Stock:";
            // 
            // stockInput
            // 
            stockInput.Location = new Point(115, 167);
            stockInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            stockInput.Name = "stockInput";
            stockInput.Size = new Size(200, 23);
            stockInput.TabIndex = 6;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(115, 220);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(90, 30);
            saveBtn.TabIndex = 7;
            saveBtn.Text = "Guardar";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += OnSaveClick;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(225, 220);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(90, 30);
            cancelBtn.TabIndex = 8;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += OnCancelClick;
            // 
            // ProductForm
            // 
            AcceptButton = saveBtn;
            CancelButton = cancelBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 280);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(stockInput);
            Controls.Add(stockLabel);
            Controls.Add(priceInput);
            Controls.Add(priceLabel);
            Controls.Add(nameTxt);
            Controls.Add(nameLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Producto";
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)stockInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label nameLabel;
        private Label priceLabel;
        private Label stockLabel;
        private TextBox nameTxt;
        private NumericUpDown priceInput;
        private NumericUpDown stockInput;
        private Button saveBtn;
        private Button cancelBtn;
    }
}
