namespace konveksi_apps.Nota_Penjualan
{
    partial class FormNotifikasiNotaJual
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
            this.dataGridViewNotaJual = new System.Windows.Forms.DataGridView();
            this.buttonCek = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotaJual)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNotaJual
            // 
            this.dataGridViewNotaJual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewNotaJual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotaJual.Location = new System.Drawing.Point(12, 78);
            this.dataGridViewNotaJual.Name = "dataGridViewNotaJual";
            this.dataGridViewNotaJual.Size = new System.Drawing.Size(642, 389);
            this.dataGridViewNotaJual.TabIndex = 32;
            // 
            // buttonCek
            // 
            this.buttonCek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCek.BackColor = System.Drawing.Color.Firebrick;
            this.buttonCek.FlatAppearance.BorderSize = 0;
            this.buttonCek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCek.ForeColor = System.Drawing.Color.White;
            this.buttonCek.Location = new System.Drawing.Point(533, 492);
            this.buttonCek.Name = "buttonCek";
            this.buttonCek.Size = new System.Drawing.Size(121, 37);
            this.buttonCek.TabIndex = 34;
            this.buttonCek.Text = "CEK";
            this.buttonCek.UseVisualStyleBackColor = false;
            this.buttonCek.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Firebrick;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(642, 53);
            this.label1.TabIndex = 35;
            this.label1.Text = "Pesanan Yang Harus Diselesaikan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormNotifikasiNotaJual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 540);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCek);
            this.Controls.Add(this.dataGridViewNotaJual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNotifikasiNotaJual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNotifikasiNotaJual";
            this.Load += new System.EventHandler(this.FormNotifikasiNotaJual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotaJual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNotaJual;
        private System.Windows.Forms.Button buttonCek;
        private System.Windows.Forms.Label label1;
    }
}