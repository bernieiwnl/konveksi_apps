using konveksi_apps.Jabatan;
using konveksi_apps.Kategori;
using konveksi_apps.Pegawai;
using konveksi_apps.Pelanggan;
using konveksi_apps.Supplier;
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
    public partial class FormLaporanMaster : Form
    {
        public FormLaporanMaster()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormDaftarPegawai frm = new FormDaftarPegawai();
            frm.Owner = this;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDaftarBarang frm = new FormDaftarBarang();
            frm.Owner = this;
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDaftarPelanggan frm = new FormDaftarPelanggan();
            frm.Owner = this;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDaftarSupplier frm = new FormDaftarSupplier();
            frm.Owner = this;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDaftarKategori frm = new FormDaftarKategori();
            frm.Owner = this;
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormDaftarJabatan frm = new FormDaftarJabatan();
            frm.Owner = this;
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
