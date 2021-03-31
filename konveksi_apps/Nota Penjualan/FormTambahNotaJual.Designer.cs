namespace konveksi_apps.Nota_Penjualan
{
    partial class FormTambahNotaJual
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonKurangi = new System.Windows.Forms.Button();
            this.dataGridViewNotaJual = new System.Windows.Forms.DataGridView();
            this.textBoxJumlah = new System.Windows.Forms.TextBox();
            this.buttonCetak = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxNamaBarang = new System.Windows.Forms.ComboBox();
            this.comboBoxstts = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePickerSelesai = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxHargaBrg = new System.Windows.Forms.TextBox();
            this.textBoxKodeBrg = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.labelTotalHarga = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNamaPegawai = new System.Windows.Forms.Label();
            this.labelKodePgw = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerNota = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPelanggan = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAlamat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNoNota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotaJual)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Firebrick;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(406, 502);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 26);
            this.buttonClose.TabIndex = 33;
            this.buttonClose.Text = "KELUAR";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonKurangi
            // 
            this.buttonKurangi.BackColor = System.Drawing.Color.Firebrick;
            this.buttonKurangi.FlatAppearance.BorderSize = 0;
            this.buttonKurangi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKurangi.ForeColor = System.Drawing.Color.White;
            this.buttonKurangi.Location = new System.Drawing.Point(437, 251);
            this.buttonKurangi.Name = "buttonKurangi";
            this.buttonKurangi.Size = new System.Drawing.Size(31, 26);
            this.buttonKurangi.TabIndex = 48;
            this.buttonKurangi.Text = "-";
            this.buttonKurangi.UseVisualStyleBackColor = false;
            this.buttonKurangi.Click += new System.EventHandler(this.buttonKurangi_Click);
            // 
            // dataGridViewNotaJual
            // 
            this.dataGridViewNotaJual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotaJual.Location = new System.Drawing.Point(7, 281);
            this.dataGridViewNotaJual.Name = "dataGridViewNotaJual";
            this.dataGridViewNotaJual.Size = new System.Drawing.Size(461, 155);
            this.dataGridViewNotaJual.TabIndex = 47;
            // 
            // textBoxJumlah
            // 
            this.textBoxJumlah.Location = new System.Drawing.Point(351, 255);
            this.textBoxJumlah.Name = "textBoxJumlah";
            this.textBoxJumlah.Size = new System.Drawing.Size(44, 20);
            this.textBoxJumlah.TabIndex = 46;
            this.textBoxJumlah.TextChanged += new System.EventHandler(this.textBoxJumlah_TextChanged);
            // 
            // buttonCetak
            // 
            this.buttonCetak.BackColor = System.Drawing.Color.Firebrick;
            this.buttonCetak.FlatAppearance.BorderSize = 0;
            this.buttonCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCetak.ForeColor = System.Drawing.Color.White;
            this.buttonCetak.Location = new System.Drawing.Point(105, 502);
            this.buttonCetak.Name = "buttonCetak";
            this.buttonCetak.Size = new System.Drawing.Size(75, 26);
            this.buttonCetak.TabIndex = 32;
            this.buttonCetak.Text = "CETAK";
            this.buttonCetak.UseVisualStyleBackColor = false;
            this.buttonCetak.Click += new System.EventHandler(this.buttonCetak_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.Firebrick;
            this.buttonSimpan.FlatAppearance.BorderSize = 0;
            this.buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(18, 502);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 26);
            this.buttonSimpan.TabIndex = 31;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.Controls.Add(this.comboBoxNamaBarang);
            this.panel1.Controls.Add(this.comboBoxstts);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dateTimePickerSelesai);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.buttonKurangi);
            this.panel1.Controls.Add(this.dataGridViewNotaJual);
            this.panel1.Controls.Add(this.textBoxJumlah);
            this.panel1.Controls.Add(this.textBoxHargaBrg);
            this.panel1.Controls.Add(this.textBoxKodeBrg);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.buttonPlus);
            this.panel1.Controls.Add(this.labelTotalHarga);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelNamaPegawai);
            this.panel1.Controls.Add(this.labelKodePgw);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dateTimePickerNota);
            this.panel1.Controls.Add(this.comboBoxPelanggan);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxAlamat);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxNoNota);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 439);
            this.panel1.TabIndex = 30;
            // 
            // comboBoxNamaBarang
            // 
            this.comboBoxNamaBarang.FormattingEnabled = true;
            this.comboBoxNamaBarang.Location = new System.Drawing.Point(6, 254);
            this.comboBoxNamaBarang.Name = "comboBoxNamaBarang";
            this.comboBoxNamaBarang.Size = new System.Drawing.Size(198, 21);
            this.comboBoxNamaBarang.TabIndex = 53;
            this.comboBoxNamaBarang.SelectedIndexChanged += new System.EventHandler(this.comboBoxNamaBarang_SelectedIndexChanged);
            // 
            // comboBoxstts
            // 
            this.comboBoxstts.FormattingEnabled = true;
            this.comboBoxstts.Items.AddRange(new object[] {
            "Cek Bahan Baku",
            "Proses Produksi",
            "Selesai"});
            this.comboBoxstts.Location = new System.Drawing.Point(72, 174);
            this.comboBoxstts.Name = "comboBoxstts";
            this.comboBoxstts.Size = new System.Drawing.Size(393, 21);
            this.comboBoxstts.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Status:";
            // 
            // dateTimePickerSelesai
            // 
            this.dateTimePickerSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSelesai.Location = new System.Drawing.Point(295, 33);
            this.dateTimePickerSelesai.Name = "dateTimePickerSelesai";
            this.dateTimePickerSelesai.Size = new System.Drawing.Size(170, 20);
            this.dateTimePickerSelesai.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Tanggal  Selesai:";
            // 
            // textBoxHargaBrg
            // 
            this.textBoxHargaBrg.Location = new System.Drawing.Point(262, 255);
            this.textBoxHargaBrg.Name = "textBoxHargaBrg";
            this.textBoxHargaBrg.Size = new System.Drawing.Size(81, 20);
            this.textBoxHargaBrg.TabIndex = 45;
            // 
            // textBoxKodeBrg
            // 
            this.textBoxKodeBrg.Location = new System.Drawing.Point(210, 255);
            this.textBoxKodeBrg.Name = "textBoxKodeBrg";
            this.textBoxKodeBrg.Size = new System.Drawing.Size(46, 20);
            this.textBoxKodeBrg.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Nama Barang";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(281, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Harga";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Jumlah";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Kode";
            // 
            // buttonPlus
            // 
            this.buttonPlus.BackColor = System.Drawing.Color.Firebrick;
            this.buttonPlus.FlatAppearance.BorderSize = 0;
            this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlus.ForeColor = System.Drawing.Color.White;
            this.buttonPlus.Location = new System.Drawing.Point(401, 251);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(31, 26);
            this.buttonPlus.TabIndex = 38;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = false;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // labelTotalHarga
            // 
            this.labelTotalHarga.AutoSize = true;
            this.labelTotalHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalHarga.Location = new System.Drawing.Point(349, 198);
            this.labelTotalHarga.Name = "labelTotalHarga";
            this.labelTotalHarga.Size = new System.Drawing.Size(127, 37);
            this.labelTotalHarga.TabIndex = 27;
            this.labelTotalHarga.Text = "TOTAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "-";
            // 
            // labelNamaPegawai
            // 
            this.labelNamaPegawai.AutoSize = true;
            this.labelNamaPegawai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaPegawai.Location = new System.Drawing.Point(125, 216);
            this.labelNamaPegawai.Name = "labelNamaPegawai";
            this.labelNamaPegawai.Size = new System.Drawing.Size(91, 13);
            this.labelNamaPegawai.TabIndex = 25;
            this.labelNamaPegawai.Text = "Nama Pegawai";
            // 
            // labelKodePgw
            // 
            this.labelKodePgw.AutoSize = true;
            this.labelKodePgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKodePgw.Location = new System.Drawing.Point(69, 216);
            this.labelKodePgw.Name = "labelKodePgw";
            this.labelKodePgw.Size = new System.Drawing.Size(35, 13);
            this.labelKodePgw.TabIndex = 24;
            this.labelKodePgw.Text = "kode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Pegawai :";
            // 
            // dateTimePickerNota
            // 
            this.dateTimePickerNota.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNota.Location = new System.Drawing.Point(296, 7);
            this.dateTimePickerNota.Name = "dateTimePickerNota";
            this.dateTimePickerNota.Size = new System.Drawing.Size(170, 20);
            this.dateTimePickerNota.TabIndex = 22;
            // 
            // comboBoxPelanggan
            // 
            this.comboBoxPelanggan.FormattingEnabled = true;
            this.comboBoxPelanggan.Location = new System.Drawing.Point(72, 67);
            this.comboBoxPelanggan.Name = "comboBoxPelanggan";
            this.comboBoxPelanggan.Size = new System.Drawing.Size(393, 21);
            this.comboBoxPelanggan.TabIndex = 20;
            this.comboBoxPelanggan.SelectedIndexChanged += new System.EventHandler(this.comboBoxPelanggan_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Pelanggan :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tanggal :";
            // 
            // textBoxAlamat
            // 
            this.textBoxAlamat.Location = new System.Drawing.Point(72, 92);
            this.textBoxAlamat.Multiline = true;
            this.textBoxAlamat.Name = "textBoxAlamat";
            this.textBoxAlamat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxAlamat.Size = new System.Drawing.Size(393, 76);
            this.textBoxAlamat.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Alamat :";
            // 
            // textBoxNoNota
            // 
            this.textBoxNoNota.Location = new System.Drawing.Point(63, 7);
            this.textBoxNoNota.Name = "textBoxNoNota";
            this.textBoxNoNota.Size = new System.Drawing.Size(141, 20);
            this.textBoxNoNota.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "No.Nota :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Firebrick;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 37);
            this.label1.TabIndex = 29;
            this.label1.Text = "TAMBAH NOTA JUAL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTambahNotaJual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 540);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCetak);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTambahNotaJual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTambahNotaJual";
            this.Load += new System.EventHandler(this.FormTambahNotaJual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotaJual)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonKurangi;
        private System.Windows.Forms.DataGridView dataGridViewNotaJual;
        private System.Windows.Forms.TextBox textBoxJumlah;
        private System.Windows.Forms.Button buttonCetak;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxHargaBrg;
        private System.Windows.Forms.TextBox textBoxKodeBrg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonPlus;
        public System.Windows.Forms.Label labelTotalHarga;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label labelNamaPegawai;
        public System.Windows.Forms.Label labelKodePgw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerNota;
        private System.Windows.Forms.ComboBox comboBoxPelanggan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAlamat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNoNota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxstts;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePickerSelesai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxNamaBarang;
    }
}