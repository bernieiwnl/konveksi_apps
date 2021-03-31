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
    public partial class FormHapusJabatan : Form
    {
        public FormHapusJabatan()
        {
            InitializeComponent();
        }

        private void FormHapusJabatan_Load(object sender, EventArgs e)
        {
            textBoxId.MaxLength = 2;
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data jabatan akan terhapus. Apakah anda yakin ? ", "KONFIRMASI", MessageBoxButtons.YesNo);
            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                jabatan ja = new jabatan(textBoxId.Text, textBoxNama.Text);
                DaftarJabatan daftar = new DaftarJabatan();
                string hasilHapus = daftar.HapusData(ja);

                if (hasilHapus == "sukses")
                {
                    MessageBox.Show("Data jabatan telah dihapus", "Info");

                    buttonKosongi_Click(buttonHapus, e);
                }
                else
                {
                    MessageBox.Show("Data jabatan gagal dihapus. Pesan kesalahan : " + hasilHapus, "Kesalahan");
                }
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
                        textBoxNama.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Kode jabatan tidak ditemukan. Proses hapus data tidak bisa dilakukan.");
                        textBoxNama.Text = "";
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
