namespace EndPoint.WinApp.Forms
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tarikh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shomare = new System.Windows.Forms.TextBox();
            this.Maliati = new System.Windows.Forms.TextBox();
            this.tarikhshamsi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tarikh
            // 
            this.tarikh.Location = new System.Drawing.Point(396, 128);
            this.tarikh.Name = "tarikh";
            this.tarikh.Size = new System.Drawing.Size(117, 23);
            this.tarikh.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(701, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "تاریخ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(701, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "شماره صورتحساب";
            // 
            // shomare
            // 
            this.shomare.Location = new System.Drawing.Point(570, 162);
            this.shomare.Name = "shomare";
            this.shomare.Size = new System.Drawing.Size(117, 23);
            this.shomare.TabIndex = 9;
            // 
            // Maliati
            // 
            this.Maliati.Location = new System.Drawing.Point(306, 162);
            this.Maliati.Name = "Maliati";
            this.Maliati.Size = new System.Drawing.Size(207, 23);
            this.Maliati.TabIndex = 11;
            // 
            // tarikhshamsi
            // 
            this.tarikhshamsi.Location = new System.Drawing.Point(570, 128);
            this.tarikhshamsi.Name = "tarikhshamsi";
            this.tarikhshamsi.Size = new System.Drawing.Size(117, 23);
            this.tarikhshamsi.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tarikhshamsi);
            this.Controls.Add(this.Maliati);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shomare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tarikh);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tarikh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox shomare;
        private System.Windows.Forms.TextBox Maliati;
        private System.Windows.Forms.TextBox tarikhshamsi;
    }
}