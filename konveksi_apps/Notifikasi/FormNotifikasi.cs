using konveksi_apps.Barang;
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

namespace konveksi_apps.Notifikasi
{
    public partial class FormNotifikasi : Form
    {
        public FormNotifikasi()
        {
            InitializeComponent();
        }



        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifjual_Click(object sender, EventArgs e)
        {
            FormNotifikasiNotaJual notaJ = new FormNotifikasiNotaJual();
            notaJ.Show();
        }

        private void notifbahanbaku_Click(object sender, EventArgs e)
        {
            FormNotifikasiBarang barangj = new FormNotifikasiBarang();
            barangj.Show();
        }

        private void notifikasiBahanBaku_Click(object sender, EventArgs e)
        {
            FormNotifikasiBahan barangK = new FormNotifikasiBahan();
            barangK.Show();
        }
    }
}
