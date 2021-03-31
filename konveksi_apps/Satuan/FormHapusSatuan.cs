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
    public partial class FormHapusSatuan : Form
    {
        public FormHapusSatuan()
        {
            InitializeComponent();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxNama.Text = "";
            textBoxId.Focus();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data satuan akan terhapus. Apakah anda yakin ? ", "KONFIRMASI", MessageBoxButtons.YesNo);
            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                satuan sa = new satuan(textBoxId.Text, textBoxNama.Text);
                DaftarSatuan daftar = new DaftarSatuan();
                string hasilHapus = daftar.HapusData(sa);

                if (hasilHapus == "sukses")
                {
                    MessageBox.Show("Data satuan telah dihapus", "Info");

                    buttonKosongi_Click(buttonHapus, e);
                }
                else
                {
                    MessageBox.Show("Data satuan gagal dihapus. Pesan kesalahan : " + hasilHapus, "Kesalahan");
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarSatuan frm = (FormDaftarSatuan)this.Owner;
            frm.FormDaftarSatuan_Load(sender, e);
            this.Close();
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
                        textBoxNama.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Kode Satuan tidak ditemukan. Proses hapus data tidak bisa dilakukan.");
                        textBoxNama.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankkan. Eror: " + hasil);
                }
            }
        }

        private void FormHapusSatuan_Load(object sender, EventArgs e)
        {
            textBoxId.MaxLength = 2;
        }
    }
 
}
