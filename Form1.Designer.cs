namespace SubirFotoWebBrazalete
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtbraza = new System.Windows.Forms.TextBox();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.lblruta = new System.Windows.Forms.Label();
            this.cmbParque = new System.Windows.Forms.ComboBox();
            this.cmbRuta = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Subír Brazalete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbraza
            // 
            this.txtbraza.Location = new System.Drawing.Point(98, 70);
            this.txtbraza.Name = "txtbraza";
            this.txtbraza.Size = new System.Drawing.Size(100, 20);
            this.txtbraza.TabIndex = 1;
            this.txtbraza.Text = "974136";
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(98, 115);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(100, 20);
            this.txtfecha.TabIndex = 2;
            this.txtfecha.Text = "2018-05-22";
            // 
            // lblruta
            // 
            this.lblruta.AutoSize = true;
            this.lblruta.Location = new System.Drawing.Point(95, 207);
            this.lblruta.Name = "lblruta";
            this.lblruta.Size = new System.Drawing.Size(51, 13);
            this.lblruta.TabIndex = 3;
            this.lblruta.Text = "Mensage";
            // 
            // cmbParque
            // 
            this.cmbParque.FormattingEnabled = true;
            this.cmbParque.Items.AddRange(new object[] {
            "Xcaret",
            "Xelha",
            "Xenotes",
            "Xplor"});
            this.cmbParque.Location = new System.Drawing.Point(265, 68);
            this.cmbParque.Name = "cmbParque";
            this.cmbParque.Size = new System.Drawing.Size(121, 21);
            this.cmbParque.TabIndex = 4;
            // 
            // cmbRuta
            // 
            this.cmbRuta.FormattingEnabled = true;
            this.cmbRuta.Items.AddRange(new object[] {
            "Producción",
            "Historico"});
            this.cmbRuta.Location = new System.Drawing.Point(265, 113);
            this.cmbRuta.Name = "cmbRuta";
            this.cmbRuta.Size = new System.Drawing.Size(121, 21);
            this.cmbRuta.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Subír Original";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbRuta);
            this.Controls.Add(this.cmbParque);
            this.Controls.Add(this.lblruta);
            this.Controls.Add(this.txtfecha);
            this.Controls.Add(this.txtbraza);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtbraza;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label lblruta;
        private System.Windows.Forms.ComboBox cmbParque;
        private System.Windows.Forms.ComboBox cmbRuta;
        private System.Windows.Forms.Button button2;
    }
}

