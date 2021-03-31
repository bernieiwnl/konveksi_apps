namespace konveksi_apps.Barang
{
    partial class FormTambahBarang
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
            this.buttonCetakBarcode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxKategori = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxStok = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHarga = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNamaBrg = new System.Windows.Forms.TextBox();
            this.textBoxKodeBrg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSatuan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMinimal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCetakBarcode
            // 
            this.buttonCetakBarcode.BackColor = System.Drawing.Color.Navy;
            this.buttonCetakBarcode.FlatAppearance.BorderSize = 0;
            this.buttonCetakBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCetakBarcode.ForeColor = System.Drawing.Color.White;
            this.buttonCetakBarcode.Location = new System.Drawing.Point(174, 260);
            this.buttonCetakBarcode.Name = "buttonCetakBarcode";
            this.buttonCetakBarcode.Size = new System.Drawing.Size(107, 32);
            this.buttonCetakBarcode.TabIndex = 25;
            this.buttonCetakBarcode.Text = "CETAK BARCODE";
            this.buttonCetakBarcode.UseVisualStyleBackColor = false;
            this.buttonCetakBarcode.Click += new System.EventHandler(this.buttonCetakBarcode_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 37);
            this.label1.TabIndex = 20;
            this.label1.Text = "TAMBAH BARANG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(342, 260);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(75, 32);
            this.buttonKeluar.TabIndex = 24;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.Navy;
            this.buttonKosongi.FlatAppearance.BorderSize = 0;
            this.buttonKosongi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(93, 260);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(75, 32);
            this.buttonKosongi.TabIndex = 23;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.Navy;
            this.buttonSimpan.FlatAppearance.BorderSize = 0;
            this.buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(12, 260);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 32);
            this.buttonSimpan.TabIndex = 22;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxMinimal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBoxSatuan);
            this.panel1.Controls.Add(this.comboBoxKategori);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxStok);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxHarga);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxNamaBrg);
            this.panel1.Controls.Add(this.textBoxKodeBrg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 197);
            this.panel1.TabIndex = 21;
            // 
            // comboBoxKategori
            // 
            this.comboBoxKategori.FormattingEnabled = true;
            this.comboBoxKategori.Location = new System.Drawing.Point(90, 113);
            this.comboBoxKategori.Name = "comboBoxKategori";
            this.comboBoxKategori.Size = new System.Drawing.Size(298, 21);
            this.comboBoxKategori.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kategori :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Stok :";
            // 
            // textBoxStok
            // 
            this.textBoxStok.Location = new System.Drawing.Point(89, 87);
            this.textBoxStok.Name = "textBoxStok";
            this.textBoxStok.Size = new System.Drawing.Size(300, 20);
            this.textBoxStok.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Harga Jual :";
            // 
            // textBoxHarga
            // 
            this.textBoxHarga.Location = new System.Drawing.Point(89, 61);
            this.textBoxHarga.Name = "textBoxHarga";
            this.textBoxHarga.Size = new System.Drawing.Size(300, 20);
            this.textBoxHarga.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nama Barang :";
            // 
            // textBoxNamaBrg
            // 
            this.textBoxNamaBrg.Location = new System.Drawing.Point(90, 34);
            this.textBoxNamaBrg.Name = "textBoxNamaBrg";
            this.textBoxNamaBrg.Size = new System.Drawing.Size(299, 20);
            this.textBoxNamaBrg.TabIndex = 4;
            // 
            // textBoxKodeBrg
            // 
            this.textBoxKodeBrg.Location = new System.Drawing.Point(90, 7);
            this.textBoxKodeBrg.Name = "textBoxKodeBrg";
            this.textBoxKodeBrg.Size = new System.Drawing.Size(299, 20);
            this.textBoxKodeBrg.TabIndex = 3;
            this.textBoxKodeBrg.TextChanged += new System.EventHandler(this.textBoxKodeBrg_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kode Barang :";
            // 
            // comboBoxSatuan
            // 
            this.comboBoxSatuan.FormattingEnabled = true;
            this.comboBoxSatuan.Location = new System.Drawing.Point(89, 140);
            this.comboBoxSatuan.Name = "comboBoxSatuan";
            this.comboBoxSatuan.Size = new System.Drawing.Size(298, 21);
            this.comboBoxSatuan.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Satuan :";
            // 
            // textBoxMinimal
            // 
            this.textBoxMinimal.Location = new System.Drawing.Point(87, 167);
            this.textBoxMinimal.Name = "textBoxMinimal";
            this.textBoxMinimal.Size = new System.Drawing.Size(300, 20);
            this.textBoxMinimal.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Minimal :";
            // 
            // FormTambahBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 298);
            this.Controls.Add(this.buttonCetakBarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTambahBarang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTambahBarang";
            this.Load += new System.EventHandler(this.FormTambahBarang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCetakBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxKategori;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxStok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHarga;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNamaBrg;
        private System.Windows.Forms.TextBox textBoxKodeBrg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMinimal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxSatuan;
    }
}