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
namespace konveksi_apps.Jabatan
{
    public partial class FormUbahJabatan : Form
    {
        public FormUbahJabatan()
        {
            InitializeComponent();
        }

        private void FormUbahJabatan_Load(object sender, EventArgs e)
        {
            textBoxId.MaxLength = 2;
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxId.Text.Length == textBoxId.MaxLength)
            {
                DaftarJabatan daftar = new DaftarJabatan();
                string hasil = daftar.CariData("IdJabatan", textBoxId.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahJabatan > 0)
                    {
                        textBoxNama.Text = daftar.ListJabatan[0].NamaJabatan;
                        textBoxNama.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode jabatan tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
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
            jabatan ja = new jabatan(textBoxId.Text, textBoxNama.Text);
            DaftarJabatan daftar = new DaftarJabatan();
            string hasilUbah = daftar.UbahData(ja);

            if (hasilUbah == "sukses")
            {
                MessageBox.Show("Data jabatan telah diubah", "Info");

                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data jabatan gagal diubah. Eror : " + hasilUbah, "Kesalahan");
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
            FormDaftarJabatan frm = (FormDaftarJabatan)this.Owner;
            frm.FormDaftarJabatan_Load(sender, e);
            this.Close();

        }
    }
}
