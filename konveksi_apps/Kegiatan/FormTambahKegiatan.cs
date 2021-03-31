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

namespace konveksi_apps.Kegiatan
{
    public partial class FormTambahKegiatan : Form
    {
        public FormTambahKegiatan()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            kegiatan keg = new kegiatan(idKegiatan.Text, namaKegiatan.Text);
            DaftarKegiatan daftar = new DaftarKegiatan();
            string hasilSimpan = daftar.TambahData(keg);
            if (hasilSimpan == "sukses")
            {
                MessageBox.Show("Data kegiatan berhasil disimpan", "Info");

            }
            else
            {
                MessageBox.Show("Data kegiatan gagal tersimpan. eror : " + hasilSimpan, "Kesalahan");

            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            namaKegiatan.Text = "";
            namaKegiatan.Focus();
        }

        private void FormTambahKegiatan_Load(object sender, EventArgs e)
        {
            DaftarKegiatan daftar = new DaftarKegiatan();
            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                idKegiatan.Text = daftar.KodeTerbaru;
                idKegiatan.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Eror: " + hasil);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKegiatan frm = (FormDaftarKegiatan)this.Owner;
            frm.FormDaftarKegiatan_Load(sender, e);
            this.Close();
        }
    }
}
