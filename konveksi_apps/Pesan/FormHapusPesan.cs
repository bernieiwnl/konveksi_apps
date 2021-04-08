using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonveksiClass;

namespace konveksi_apps.Pesan
{
    public partial class FormHapusPesan : Form
    {
        public FormHapusPesan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Pesan akan terhapus. Apakah anda yakin ? ", "KONFIRMASI", MessageBoxButtons.YesNo);
            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                pesan sa = new pesan(textBoxId.Text, null,null,null);
                DaftarPesan daftar = new DaftarPesan();
                string hasilHapus = daftar.HapusData(sa);

                if (hasilHapus == "sukses")
                {
                    MessageBox.Show("Data Pesan telah dihapus", "Info");
                }
                else
                {
                    MessageBox.Show("Data satuan gagal dihapus. Pesan kesalahan : " + hasilHapus, "Kesalahan");
                }
            }
        }

        private void FormHapusPesan_Load(object sender, EventArgs e)
        {

        }
    }
}
