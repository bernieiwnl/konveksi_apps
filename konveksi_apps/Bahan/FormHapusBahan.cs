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

namespace konveksi_apps.Bahan
{
    public partial class FormHapusBahan : Form
    {
        public FormHapusBahan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarBahan frm = (FormDaftarBahan)this.Owner;
            frm.FormDaftarBahan_Load(sender, e);
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxNama.Text = "";
            textBoxStok.Text = "";
            textBoxHargaBeli.Text = "";
            textBoxId.Focus();
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxId.Text.Length == textBoxId.MaxLength)
            {
                DaftarBahan daftar = new DaftarBahan();
                string hasil = daftar.CariData("bahan.id", textBoxId.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahBahan > 0)
                    {
                        textBoxNama.Text = daftar.ListBahan[0].NamaBahan;
                        textBoxStok.Text = daftar.ListBahan[0].Stok.ToString();
                        textBoxHargaBeli.Text = daftar.ListBahan[0].HargaBeli.ToString();
                        textBoxNama.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Kode bahan tidak ditemukan. Proses hapus data tidak bisa dilakukan.");
                        textBoxId.Text = "";
                        textBoxNama.Text = "";
                        textBoxStok.Text = "";
                        textBoxHargaBeli.Text = "";
                        textBoxId.Focus();
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

            DialogResult konfirmasi = MessageBox.Show("Data bahan hapus akan terhapus. Apakah anda yakin ? ", "KONFIRMASI", MessageBoxButtons.YesNo);
            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                bahan ja = new bahan(textBoxId.Text, textBoxNama.Text, int.Parse(textBoxStok.Text), int.Parse(textBoxHargaBeli.Text), null , null, null,0);
                DaftarBahan daftar = new DaftarBahan();
                string hasilHapus = daftar.HapusData(ja);

                if (hasilHapus == "sukses")
                {
                    MessageBox.Show("Data bahan telah dihapus", "Info");

                    textBoxId.Text = "";
                    textBoxNama.Text = "";
                    textBoxStok.Text = "";
                    textBoxHargaBeli.Text = "";
                    textBoxId.Focus();
                }
                else
                {
                    MessageBox.Show("Data bahan gagal dihapus. Pesan kesalahan : " + hasilHapus, "Kesalahan");
                }
            }
        }

        private void FormHapusBahan_Load(object sender, EventArgs e)
        {
            textBoxId.MaxLength = 5;
        }
    }
}
