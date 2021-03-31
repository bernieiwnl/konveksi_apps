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

namespace konveksi_apps.Jenis_Bahan
{
    public partial class FormUbahJenisBahan : Form
    {
        public FormUbahJenisBahan()
        {
            InitializeComponent();
        }

        private void FormUbahJenisBahan_Load(object sender, EventArgs e)
        {
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxId.Text.Length > 2)
            {
                DaftarJenisBahan daftar = new DaftarJenisBahan();
                string hasil = daftar.CariData("id", textBoxId.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahJenisBahan > 0)
                    {
                        textBoxNama.Text = daftar.ListJenisBahan[0].Nama_bahan;
                        textBoxNama.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode jenis bhaan tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
                        textBoxNama.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankkan. Eror: " + hasil);
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            jenisBahan JB = new jenisBahan(textBoxId.Text, textBoxNama.Text);
            DaftarJenisBahan daftar = new DaftarJenisBahan();
            string hasilUbah = daftar.UbahData(JB);

            if (hasilUbah == "sukses")
            {
                MessageBox.Show("Data jenis bahan telah diubah", "Info");

                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data jenis bahan gagal diubah. Eror : " + hasilUbah, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxNama.Text = "";
            textBoxId.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarJenisBahan frm = (FormDaftarJenisBahan)this.Owner;
            frm.FormDaftarJenisBahan_Load(sender, e);
            this.Close();
        }
    }
}
