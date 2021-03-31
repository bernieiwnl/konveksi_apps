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
    public partial class FormUbahKegiatan : Form
    {
        public FormUbahKegiatan()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            kegiatan ja = new kegiatan(idKegiatan.Text, namaKegiatan.Text);
            DaftarKegiatan daftar = new DaftarKegiatan();
            string hasilUbah = daftar.UbahData(ja);

            if (hasilUbah == "sukses")
            {
                MessageBox.Show("Data Kegiatan telah diubah", "Info");
                idKegiatan.Text = "";
                namaKegiatan.Text = "";
                namaKegiatan.Focus();
            }
            else
            {
                MessageBox.Show("Data Kegiatan gagal diubah. Eror : " + hasilUbah, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            idKegiatan.Text = "";
            namaKegiatan.Text = "";
            idKegiatan.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKegiatan frm = (FormDaftarKegiatan)this.Owner;
            frm.FormDaftarKegiatan_Load(sender, e);
            this.Close();
        }

        private void FormUbahKegiatan_Load(object sender, EventArgs e)
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
                        namaKegiatan.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode Kegiatan tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
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
