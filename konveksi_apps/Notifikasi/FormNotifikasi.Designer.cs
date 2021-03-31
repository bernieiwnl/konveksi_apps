namespace konveksi_apps.Notifikasi
{
    partial class FormNotifikasi
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
            this.notifjual = new System.Windows.Forms.Button();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.notifbahanbaku = new System.Windows.Forms.Button();
            this.notifikasiBahanBaku = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 37);
            this.label1.TabIndex = 34;
            this.label1.Text = "NOTIFIKASI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifjual
            // 
            this.notifjual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.notifjual.FlatAppearance.BorderSize = 0;
            this.notifjual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notifjual.ForeColor = System.Drawing.Color.White;
            this.notifjual.Location = new System.Drawing.Point(10, 49);
            this.notifjual.Name = "notifjual";
            this.notifjual.Size = new System.Drawing.Size(221, 51);
            this.notifjual.TabIndex = 36;
            this.notifjual.Text = "NOTIFIKASI PENJUALAN";
            this.notifjual.UseVisualStyleBackColor = false;
            this.notifjual.Click += new System.EventHandler(this.notifjual_Click);
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(235, 102);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(211, 51);
            this.buttonKeluar.TabIndex = 37;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // notifbahanbaku
            // 
            this.notifbahanbaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.notifbahanbaku.FlatAppearance.BorderSize = 0;
            this.notifbahanbaku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notifbahanbaku.ForeColor = System.Drawing.Color.White;
            this.notifbahanbaku.Location = new System.Drawing.Point(235, 49);
            this.notifbahanbaku.Name = "notifbahanbaku";
            this.notifbahanbaku.Size = new System.Drawing.Size(211, 51);
            this.notifbahanbaku.TabIndex = 38;
            this.notifbahanbaku.Text = "NOTIFIKASI BARANG";
            this.notifbahanbaku.UseVisualStyleBackColor = false;
            this.notifbahanbaku.Click += new System.EventHandler(this.notifbahanbaku_Click);
            // 
            // notifikasiBahanBaku
            // 
            this.notifikasiBahanBaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.notifikasiBahanBaku.FlatAppearance.BorderSize = 0;
            this.notifikasiBahanBaku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notifikasiBahanBaku.ForeColor = System.Drawing.Color.White;
            this.notifikasiBahanBaku.Location = new System.Drawing.Point(10, 102);
            this.notifikasiBahanBaku.Name = "notifikasiBahanBaku";
            this.notifikasiBahanBaku.Size = new System.Drawing.Size(221, 51);
            this.notifikasiBahanBaku.TabIndex = 39;
            this.notifikasiBahanBaku.Text = "NOTIFIKASI BAHAN BAKU";
            this.notifikasiBahanBaku.UseVisualStyleBackColor = false;
            this.notifikasiBahanBaku.Click += new System.EventHandler(this.notifikasiBahanBaku_Click);
            // 
            // FormNotifikasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 162);
            this.Controls.Add(this.notifikasiBahanBaku);
            this.Controls.Add(this.notifbahanbaku);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.notifjual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNotifikasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notifikasi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button notifjual;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button notifbahanbaku;
        private System.Windows.Forms.Button notifikasiBahanBaku;
    }
}