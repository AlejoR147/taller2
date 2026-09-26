namespace DesktopApp
{
    partial class SalesView
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
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe Script", 20F);
            title.Location = new Point(215, 93);
            title.Name = "title";
            title.Size = new Size(285, 42);
            title.TabIndex = 1;
            title.Text = "Gestión de Ventas";
            // 
            // SalesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 572);
            Controls.Add(title);
            Name = "SalesView";
            Text = "ECommerce";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
    }
}
