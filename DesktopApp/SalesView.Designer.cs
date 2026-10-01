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
            listView1 = new ListView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe Script", 20F);
            title.Location = new Point(307, 154);
            title.Margin = new Padding(4, 0, 4, 0);
            title.Name = "title";
            title.Size = new Size(403, 64);
            title.TabIndex = 1;
            title.Text = "Gestión de Ventas";
            // 
            // listView1
            // 
            listView1.Location = new Point(163, 384);
            listView1.Margin = new Padding(4);
            listView1.Name = "listView1";
            listView1.Size = new Size(670, 301);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(496, 328);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(107, 34);
            button1.TabIndex = 3;
            button1.Text = "Eliminar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(611, 328);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(107, 34);
            button2.TabIndex = 4;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.Location = new Point(727, 328);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(107, 34);
            button3.TabIndex = 5;
            button3.Text = "Agregar";
            button3.UseVisualStyleBackColor = true;
            // 
            // SalesView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 953);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(title);
            Margin = new Padding(4);
            Name = "SalesView";
            Text = "ECommerce";
            Load += SalesView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private ListView listView1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
