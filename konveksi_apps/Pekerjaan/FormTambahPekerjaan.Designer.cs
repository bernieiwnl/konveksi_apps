namespace konveksi_apps.Pekerjaan
{
    partial class FormTambahPekerjaan
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
            this.label7 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idPekerjaan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.satuan = new System.Windows.Forms.TextBox();
            this.dateTimePickerPekerjaan = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.harga = new System.Windows.Forms.TextBox();
            this.keterangan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.idPegawai = new System.Windows.Forms.ComboBox();
            this.idBarang = new System.Windows.Forms.ComboBox();
            this.idKegiatan = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "KETERANGAN";
            this.label7.UseWaitCursor = true;
            // 
            // status
            // 
            this.status.FormattingEnabled = true;
            this.status.Items.AddRange(new object[] {
            "Selesai",
            "Belum Selesai"});
            this.status.Location = new System.Drawing.Point(115, 250);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(273, 21);
            this.status.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "STATUS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "NAMA PEGAWAI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "KEGIATAN";
            // 
            // idPekerjaan
            // 
            this.idPekerjaan.Location = new System.Drawing.Point(115, 7);
            this.idPekerjaan.Name = "idPekerjaan";
            this.idPekerjaan.Size = new System.Drawing.Size(274, 20);
            this.idPekerjaan.TabIndex = 3;
            this.idPekerjaan.TextChanged += new System.EventHandler(this.idPekerjaan_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID PEKERJAAN";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.OrangeRed;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 37);
            this.label1.TabIndex = 26;
            this.label1.Text = "TAMBAH NOTA GAJI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(343, 351);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(75, 32);
            this.buttonKeluar.TabIndex = 30;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonKosongi.FlatAppearance.BorderSize = 0;
            this.buttonKosongi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(94, 351);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(75, 32);
            this.buttonKosongi.TabIndex = 29;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonSimpan.FlatAppearance.BorderSize = 0;
            this.buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(13, 351);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 32);
            this.buttonSimpan.TabIndex = 28;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.satuan);
            this.panel1.Controls.Add(this.dateTimePickerPekerjaan);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.harga);
            this.panel1.Controls.Add(this.keterangan);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.idPegawai);
            this.panel1.Controls.Add(this.idBarang);
            this.panel1.Controls.Add(this.idKegiatan);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.status);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.idPekerjaan);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 286);
            this.panel1.TabIndex = 27;
            // 
            // satuan
            // 
            this.satuan.Location = new System.Drawing.Point(115, 170);
            this.satuan.Name = "satuan";
            this.satuan.Size = new System.Drawing.Size(274, 20);
            this.satuan.TabIndex = 36;
            // 
            // dateTimePickerPekerjaan
            // 
            this.dateTimePickerPekerjaan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerPekerjaan.Location = new System.Drawing.Point(115, 91);
            this.dateTimePickerPekerjaan.Name = "dateTimePickerPekerjaan";
            this.dateTimePickerPekerjaan.Size = new System.Drawing.Size(274, 20);
            this.dateTimePickerPekerjaan.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "SATUAN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "TANGGAL KERJA";
            // 
            // harga
            // 
            this.harga.Location = new System.Drawing.Point(116, 144);
            this.harga.Name = "harga";
            this.harga.Size = new System.Drawing.Size(274, 20);
            this.harga.TabIndex = 34;
            // 
            // keterangan
            // 
            this.keterangan.Location = new System.Drawing.Point(115, 197);
            this.keterangan.Multiline = true;
            this.keterangan.Name = "keterangan";
            this.keterangan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.keterangan.Size = new System.Drawing.Size(273, 47);
            this.keterangan.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "HARGA";
            // 
            // idPegawai
            // 
            this.idPegawai.FormattingEnabled = true;
            this.idPegawai.Location = new System.Drawing.Point(115, 64);
            this.idPegawai.Name = "idPegawai";
            this.idPegawai.Size = new System.Drawing.Size(274, 21);
            this.idPegawai.TabIndex = 16;
            // 
            // idBarang
            // 
            this.idBarang.FormattingEnabled = true;
            this.idBarang.Location = new System.Drawing.Point(115, 117);
            this.idBarang.Name = "idBarang";
            this.idBarang.Size = new System.Drawing.Size(274, 21);
            this.idBarang.TabIndex = 32;
            this.idBarang.SelectedIndexChanged += new System.EventHandler(this.idBarang_SelectedIndexChanged);
            // 
            // idKegiatan
            // 
            this.idKegiatan.FormattingEnabled = true;
            this.idKegiatan.Location = new System.Drawing.Point(115, 36);
            this.idKegiatan.Name = "idKegiatan";
            this.idKegiatan.Size = new System.Drawing.Size(274, 21);
            this.idKegiatan.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "NAMA BARANG";
            // 
            // FormTambahPekerjaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 387);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTambahPekerjaan";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormTambahPekerjaan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox idPekerjaan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox idPegawai;
        private System.Windows.Forms.ComboBox idKegiatan;
        private System.Windows.Forms.TextBox keterangan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerPekerjaan;
        private System.Windows.Forms.TextBox satuan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox harga;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox idBarang;
        private System.Windows.Forms.Label label10;
    }
}