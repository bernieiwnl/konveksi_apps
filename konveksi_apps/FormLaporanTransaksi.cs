using konveksi_apps.Nota_Pembelian;
using konveksi_apps.Nota_Penjualan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace konveksi_apps
{
    public partial class FormLaporanTransaksi : Form
    {
        public FormLaporanTransaksi()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDaftarNotaJual frm = new FormDaftarNotaJual();
            frm.Owner = this;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDaftarNotaBeli frm = new FormDaftarNotaBeli();
            frm.Owner = this;
            frm.Show();
        }
    }
}
