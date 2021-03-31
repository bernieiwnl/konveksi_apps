namespace konveksi_apps.Nota_Pembelian
{
    partial class FormTambahNotaBeli
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCetak = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxNamaBarang = new System.Windows.Forms.ComboBox();
            this.comboBoxBahanBaku = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewBarang = new System.Windows.Forms.DataGridView();
            this.textBoxJumlah = new System.Windows.Forms.TextBox();
            this.textBoxHargaBrg = new System.Windows.Forms.TextBox();
            this.textBoxKodeBrg = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.labelTotalHarga = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.labelKodePgw = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerNota = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAlamat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNoNota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonClose.Location = new System.Drawing.Point(401, 460);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 26);
            this.buttonClose.TabIndex = 37;
            this.buttonClose.Text = "KELUAR";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonKurangi
            // 
            this.buttonKurangi.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonKurangi.FlatAppearance.BorderSize = 0;
            this.buttonKurangi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKurangi.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonKurangi.Location = new System.Drawing.Point(439, 205);
            this.buttonKurangi.Name = "buttonKurangi";
            this.buttonKurangi.Size = new System.Drawing.Size(22, 24);
            this.buttonKurangi.TabIndex = 48;
            this.buttonKurangi.Text = "-";
            this.buttonKurangi.UseVisualStyleBackColor = false;
            this.buttonKurangi.Click += new System.EventHandler(this.buttonKurangi_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.YellowGreen;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 37);
            this.label1.TabIndex = 33;
            this.label1.Text = "TAMBAH NOTA BELI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCetak
            // 
            this.buttonCetak.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonCetak.FlatAppearance.BorderSize = 0;
            this.buttonCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCetak.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonCetak.Location = new System.Drawing.Point(105, 460);
            this.buttonCetak.Name = "buttonCetak";
            this.buttonCetak.Size = new System.Drawing.Size(75, 26);
            this.buttonCetak.TabIndex = 36;
            this.buttonCetak.Text = "CETAK";
            this.buttonCetak.UseVisualStyleBackColor = false;
            this.buttonCetak.Click += new System.EventHandler(this.buttonCetak_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonSimpan.FlatAppearance.BorderSize = 0;
            this.buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimpan.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonSimpan.Location = new System.Drawing.Point(18, 460);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 26);
            this.buttonSimpan.TabIndex = 35;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGreen;
            this.panel1.Controls.Add(this.comboBoxNamaBarang);
            this.panel1.Controls.Add(this.comboBoxBahanBaku);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.buttonKurangi);
            this.panel1.Controls.Add(this.dataGridViewBarang);
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
            this.panel1.Controls.Add(this.labelNama);
            this.panel1.Controls.Add(this.labelKodePgw);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dateTimePickerNota);
            this.panel1.Controls.Add(this.comboBoxSupplier);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxAlamat);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxNoNota);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 397);
            this.panel1.TabIndex = 34;
            // 
            // comboBoxNamaBarang
            // 
            this.comboBoxNamaBarang.FormattingEnabled = true;
            this.comboBoxNamaBarang.Location = new System.Drawing.Point(7, 209);
            this.comboBoxNamaBarang.Name = "comboBoxNamaBarang";
            this.comboBoxNamaBarang.Size = new System.Drawing.Size(195, 21);
            this.comboBoxNamaBarang.TabIndex = 51;
            this.comboBoxNamaBarang.SelectedIndexChanged += new System.EventHandler(this.comboBoxBarang_SelectedIndexChanged);
            // 
            // comboBoxBahanBaku
            // 
            this.comboBoxBahanBaku.FormattingEnabled = true;
            this.comboBoxBahanBaku.Location = new System.Drawing.Point(63, 36);
            this.comboBoxBahanBaku.Name = "comboBoxBahanBaku";
            this.comboBoxBahanBaku.Size = new System.Drawing.Size(389, 21);
            this.comboBoxBahanBaku.TabIndex = 50;
            this.comboBoxBahanBaku.SelectedIndexChanged += new System.EventHandler(this.comboBoxBahanBaku_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "B Baku :";
            // 
            // dataGridViewBarang
            // 
            this.dataGridViewBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarang.Location = new System.Drawing.Point(5, 235);
            this.dataGridViewBarang.Name = "dataGridViewBarang";
            this.dataGridViewBarang.Size = new System.Drawing.Size(456, 155);
            this.dataGridViewBarang.TabIndex = 47;
            // 
            // textBoxJumlah
            // 
            this.textBoxJumlah.Location = new System.Drawing.Point(349, 209);
            this.textBoxJumlah.Name = "textBoxJumlah";
            this.textBoxJumlah.Size = new System.Drawing.Size(44, 20);
            this.textBoxJumlah.TabIndex = 46;
            // 
            // textBoxHargaBrg
            // 
            this.textBoxHargaBrg.Location = new System.Drawing.Point(260, 209);
            this.textBoxHargaBrg.Name = "textBoxHargaBrg";
            this.textBoxHargaBrg.Size = new System.Drawing.Size(81, 20);
            this.textBoxHargaBrg.TabIndex = 45;
            // 
            // textBoxKodeBrg
            // 
            this.textBoxKodeBrg.Location = new System.Drawing.Point(208, 209);
            this.textBoxKodeBrg.Name = "textBoxKodeBrg";
            this.textBoxKodeBrg.Size = new System.Drawing.Size(46, 20);
            this.textBoxKodeBrg.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Nama Barang";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Harga";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Jumlah";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Kode";
            // 
            // buttonPlus
            // 
            this.buttonPlus.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonPlus.FlatAppearance.BorderSize = 0;
            this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlus.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonPlus.Location = new System.Drawing.Point(408, 205);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(22, 24);
            this.buttonPlus.TabIndex = 38;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = false;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // labelTotalHarga
            // 
            this.labelTotalHarga.AutoSize = true;
            this.labelTotalHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalHarga.Location = new System.Drawing.Point(325, 144);
            this.labelTotalHarga.Name = "labelTotalHarga";
            this.labelTotalHarga.Size = new System.Drawing.Size(127, 37);
            this.labelTotalHarga.TabIndex = 27;
            this.labelTotalHarga.Text = "TOTAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "-";
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Location = new System.Drawing.Point(162, 162);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(79, 13);
            this.labelNama.TabIndex = 25;
            this.labelNama.Text = "Nama Pegawai";
            // 
            // labelKodePgw
            // 
            this.labelKodePgw.AutoSize = true;
            this.labelKodePgw.Location = new System.Drawing.Point(123, 161);
            this.labelKodePgw.Name = "labelKodePgw";
            this.labelKodePgw.Size = new System.Drawing.Size(31, 13);
            this.labelKodePgw.TabIndex = 24;
            this.labelKodePgw.Text = "kode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Pegawai :";
            // 
            // dateTimePickerNota
            // 
            this.dateTimePickerNota.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNota.Location = new System.Drawing.Point(282, 7);
            this.dateTimePickerNota.Name = "dateTimePickerNota";
            this.dateTimePickerNota.Size = new System.Drawing.Size(170, 20);
            this.dateTimePickerNota.TabIndex = 22;
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(63, 65);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(389, 21);
            this.comboBoxSupplier.TabIndex = 20;
            this.comboBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplier_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Supplier :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tanggal :";
            // 
            // textBoxAlamat
            // 
            this.textBoxAlamat.Location = new System.Drawing.Point(63, 92);
            this.textBoxAlamat.Multiline = true;
            this.textBoxAlamat.Name = "textBoxAlamat";
            this.textBoxAlamat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxAlamat.Size = new System.Drawing.Size(389, 49);
            this.textBoxAlamat.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
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
            // FormTambahNotaBeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 493);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCetak);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTambahNotaBeli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTambahNotaBeli";
            this.Load += new System.EventHandler(this.FormTambahNotaBeli_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonKurangi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCetak;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewBarang;
        private System.Windows.Forms.TextBox textBoxJumlah;
        private System.Windows.Forms.TextBox textBoxHargaBrg;
        private System.Windows.Forms.TextBox textBoxKodeBrg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonPlus;
        public System.Windows.Forms.Label labelTotalHarga;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label labelNama;
        public System.Windows.Forms.Label labelKodePgw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerNota;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAlamat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNoNota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBahanBaku;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxNamaBarang;
    }
}