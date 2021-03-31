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
    public partial class FormHapusJenisBahan : Form
    {
        public FormHapusJenisBahan()
        {
            InitializeComponent();
        }

        private void FormHapusJenisBahan_Load(object sender, EventArgs e)
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
                        textBoxNama.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Kode jenis bahan tidak ditemukan. Proses hapus data tidak bisa dilakukan.");
                        textBoxNama.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankkan. Eror: " + hasil);
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
            FormDaftarJenisBahan frm = (FormDaftarJenisBahan)this.Owner;
            frm.FormDaftarJenisBahan_Load(sender, e);
            this.Close();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data jenis bahan akan terhapus. Apakah anda yakin ? ", "KONFIRMASI", MessageBoxButtons.YesNo);
            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                jenisBahan JB = new jenisBahan(textBoxId.Text, textBoxNama.Text);
                DaftarJenisBahan daftar = new DaftarJenisBahan();
                string hasilHapus = daftar.HapusData(JB);

                if (hasilHapus == "sukses")
                {
                    MessageBox.Show("Data jenis bahan telah dihapus", "Info");

                    buttonKosongi_Click(buttonHapus, e);
                }
                else
                {
                    MessageBox.Show("Data jenis bahan gagal dihapus. Pesan kesalahan : " + hasilHapus, "Kesalahan");
                }
            }
        }
    }
}
