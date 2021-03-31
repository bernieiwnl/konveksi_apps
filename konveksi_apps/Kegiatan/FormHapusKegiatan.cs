using KonveksiClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace konveksi_apps.Kegiatan
{
    public partial class FormHapusKegiatan : Form
    {
        public FormHapusKegiatan()
        {
            InitializeComponent();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {

            idKegiatan.Text = "";
            namaKegiatan.Text = "";
            idKegiatan.Focus();
            namaKegiatan.Enabled = true;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data Kegiatan akan terhapus. Apakah anda yakin ? ", "KONFIRMASI", MessageBoxButtons.YesNo);
            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                kegiatan kegi = new kegiatan(idKegiatan.Text, namaKegiatan.Text);
                DaftarKegiatan daftar = new DaftarKegiatan();
                string hasilHapus = daftar.HapusData(kegi);

                if (hasilHapus == "sukses")
                {
                    MessageBox.Show("Data Kegiatan telah dihapus", "Info");
                    idKegiatan.Text = "";
                    namaKegiatan.Text = "";
                    idKegiatan.Focus();
                    namaKegiatan.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Data Kegiatan gagal dihapus. Pesan kesalahan : " + hasilHapus, "Kesalahan");
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKegiatan frm = (FormDaftarKegiatan)this.Owner;
            frm.FormDaftarKegiatan_Load(sender, e);
            this.Close();
        }

        private void FormHapusKegiatan_Load(object sender, EventArgs e)
        {
            
        }

        private void idKegiatan_TextChanged(object sender, EventArgs e)
        {

            if (idKegiatan.Text.Length != 0)
            {
                DaftarKegiatan daftar = new DaftarKegiatan();
                string hasil = daftar.CariData("idKegiatan", idKegiatan.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahJabatan > 0)
                    {
                        namaKegiatan.Text = daftar.ListKegiatan[0].NamaKegiatan;
                        namaKegiatan.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Kode Kegiatan tidak ditemukan. Proses hapus data tidak bisa dilakukan.");
                        namaKegiatan.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankkan. Eror: " + hasil);
                }
            }
        }
    }
}
