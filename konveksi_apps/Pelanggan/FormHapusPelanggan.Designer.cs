namespace konveksi_apps.Pelanggan
{
    partial class FormHapusPelanggan
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTlp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAlamat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNamaPelanggan = new System.Windows.Forms.TextBox();
            this.textBoxKodePelanggan = new System.Windows.Forms.TextBox();
            this.buttonHapus = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 37);
            this.label1.TabIndex = 25;
            this.label1.Text = "HAPUS DAFTAR PELANGGAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Crimson;
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.ForeColor = System.Drawing.Color.Transparent;
            this.buttonKeluar.Location = new System.Drawing.Point(340, 194);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(75, 26);
            this.buttonKeluar.TabIndex = 28;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.Crimson;
            this.buttonKosongi.FlatAppearance.BorderSize = 0;
            this.buttonKosongi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKosongi.ForeColor = System.Drawing.Color.Transparent;
            this.buttonKosongi.Location = new System.Drawing.Point(102, 194);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(75, 26);
            this.buttonKosongi.TabIndex = 27;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kode Pelanggan :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxTlp);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxAlamat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxNamaPelanggan);
            this.panel1.Controls.Add(this.textBoxKodePelanggan);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 124);
            this.panel1.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Telepon :";
            // 
            // textBoxTlp
            // 
            this.textBoxTlp.Location = new System.Drawing.Point(102, 93);
            this.textBoxTlp.Name = "textBoxTlp";
            this.textBoxTlp.Size = new System.Drawing.Size(287, 20);
            this.textBoxTlp.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Alamat :";
            // 
            // textBoxAlamat
            // 
            this.textBoxAlamat.Location = new System.Drawing.Point(102, 64);
            this.textBoxAlamat.Name = "textBoxAlamat";
            this.textBoxAlamat.Size = new System.Drawing.Size(287, 20);
            this.textBoxAlamat.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nama Pelanggan :";
            // 
            // textBoxNamaPelanggan
            // 
            this.textBoxNamaPelanggan.Location = new System.Drawing.Point(102, 34);
            this.textBoxNamaPelanggan.Name = "textBoxNamaPelanggan";
            this.textBoxNamaPelanggan.Size = new System.Drawing.Size(287, 20);
            this.textBoxNamaPelanggan.TabIndex = 4;
            // 
            // textBoxKodePelanggan
            // 
            this.textBoxKodePelanggan.Location = new System.Drawing.Point(102, 7);
            this.textBoxKodePelanggan.Name = "textBoxKodePelanggan";
            this.textBoxKodePelanggan.Size = new System.Drawing.Size(287, 20);
            this.textBoxKodePelanggan.TabIndex = 3;
            this.textBoxKodePelanggan.TextChanged += new System.EventHandler(this.textBoxKodePelanggan_TextChanged);
            // 
            // buttonHapus
            // 
            this.buttonHapus.BackColor = System.Drawing.Color.Crimson;
            this.buttonHapus.FlatAppearance.BorderSize = 0;
            this.buttonHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHapus.ForeColor = System.Drawing.Color.Transparent;
            this.buttonHapus.Location = new System.Drawing.Point(18, 194);
            this.buttonHapus.Name = "buttonHapus";
            this.buttonHapus.Size = new System.Drawing.Size(75, 26);
            this.buttonHapus.TabIndex = 29;
            this.buttonHapus.Text = "HAPUS";
            this.buttonHapus.UseVisualStyleBackColor = false;
            this.buttonHapus.Click += new System.EventHandler(this.buttonHapus_Click);
            // 
            // FormHapusPelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 223);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonHapus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHapusPelanggan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHapusPelanggan";
            this.Load += new System.EventHandler(this.FormHapusPelanggan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTlp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAlamat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNamaPelanggan;
        private System.Windows.Forms.TextBox textBoxKodePelanggan;
        private System.Windows.Forms.Button buttonHapus;
    }
}