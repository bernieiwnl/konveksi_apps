namespace konveksi_apps.Kegiatan
{
    partial class FormUbahKegiatan
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
            System.Windows.Forms.Button buttonKeluar;
            System.Windows.Forms.Button buttonKosongi;
            System.Windows.Forms.Button buttonSimpan;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.namaKegiatan = new System.Windows.Forms.TextBox();
            this.idKegiatan = new System.Windows.Forms.TextBox();
            buttonKeluar = new System.Windows.Forms.Button();
            buttonKosongi = new System.Windows.Forms.Button();
            buttonSimpan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            buttonKeluar.BackColor = System.Drawing.Color.MediumVioletRed;
            buttonKeluar.FlatAppearance.BorderSize = 0;
            buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonKeluar.ForeColor = System.Drawing.Color.White;
            buttonKeluar.Location = new System.Drawing.Point(340, 136);
            buttonKeluar.Name = "buttonKeluar";
            buttonKeluar.Size = new System.Drawing.Size(75, 26);
            buttonKeluar.TabIndex = 33;
            buttonKeluar.Text = "KELUAR";
            buttonKeluar.UseVisualStyleBackColor = false;
            buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonKosongi
            // 
            buttonKosongi.BackColor = System.Drawing.Color.MediumVioletRed;
            buttonKosongi.FlatAppearance.BorderSize = 0;
            buttonKosongi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonKosongi.ForeColor = System.Drawing.Color.White;
            buttonKosongi.Location = new System.Drawing.Point(102, 136);
            buttonKosongi.Name = "buttonKosongi";
            buttonKosongi.Size = new System.Drawing.Size(75, 26);
            buttonKosongi.TabIndex = 32;
            buttonKosongi.Text = "KOSONGI";
            buttonKosongi.UseVisualStyleBackColor = false;
            buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonSimpan
            // 
            buttonSimpan.BackColor = System.Drawing.Color.MediumVioletRed;
            buttonSimpan.FlatAppearance.BorderSize = 0;
            buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSimpan.ForeColor = System.Drawing.Color.White;
            buttonSimpan.Location = new System.Drawing.Point(10, 136);
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.Size = new System.Drawing.Size(75, 26);
            buttonSimpan.TabIndex = 31;
            buttonSimpan.Text = "UBAH";
            buttonSimpan.UseVisualStyleBackColor = false;
            buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MediumVioletRed;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 37);
            this.label1.TabIndex = 29;
            this.label1.Text = "UBAH KEGIATAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID KEGIATAN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.namaKegiatan);
            this.panel1.Controls.Add(this.idKegiatan);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 64);
            this.panel1.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "KEGIATAN";
            // 
            // namaKegiatan
            // 
            this.namaKegiatan.Location = new System.Drawing.Point(90, 34);
            this.namaKegiatan.Name = "namaKegiatan";
            this.namaKegiatan.Size = new System.Drawing.Size(299, 20);
            this.namaKegiatan.TabIndex = 4;
            // 
            // idKegiatan
            // 
            this.idKegiatan.Location = new System.Drawing.Point(90, 7);
            this.idKegiatan.Name = "idKegiatan";
            this.idKegiatan.Size = new System.Drawing.Size(299, 20);
            this.idKegiatan.TabIndex = 3;
            this.idKegiatan.TextChanged += new System.EventHandler(this.idKegiatan_TextChanged);
            // 
            // FormUbahKegiatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 170);
            this.Controls.Add(this.label1);
            this.Controls.Add(buttonKeluar);
            this.Controls.Add(buttonKosongi);
            this.Controls.Add(buttonSimpan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUbahKegiatan";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormUbahKegiatan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox namaKegiatan;
        private System.Windows.Forms.TextBox idKegiatan;
    }
}