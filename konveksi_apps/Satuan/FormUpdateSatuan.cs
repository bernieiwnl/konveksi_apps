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

namespace konveksi_apps.Satuan
{
    public partial class FormUpdateSatuan : Form
    {
        public FormUpdateSatuan()
        {
            InitializeComponent();
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxId.Text.Length == textBoxId.MaxLength)
            {
                DaftarSatuan daftar = new DaftarSatuan();
                string hasil = daftar.CariData("id", textBoxId.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahSatuan > 0)
                    {
                        textBoxNama.Text = daftar.Satuans[0].NamaSatuan;
                        textBoxNama.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode satuan tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
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
            satuan sa = new satuan(textBoxId.Text, textBoxNama.Text);
            DaftarSatuan daftar = new DaftarSatuan();
            string hasilUbah = daftar.UbahData(sa);

            if (hasilUbah == "sukses")
            {
                MessageBox.Show("Data satuan telah diubah", "Info");

                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data satuan gagal diubah. Eror : " + hasilUbah, "Kesalahan");
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
            FormDaftarSatuan frm = (FormDaftarSatuan)this.Owner;
            frm.FormDaftarSatuan_Load(sender, e);
            this.Close();
        }

        private void FormUpdateSatuan_Load(object sender, EventArgs e)
        {
            textBoxId.MaxLength = 2;
        }
    }
}
