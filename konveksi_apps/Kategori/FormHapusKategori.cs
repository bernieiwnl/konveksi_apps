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
namespace konveksi_apps.Kategori
{
    public partial class FormHapusKategori : Form
    {
        public FormHapusKategori()
        {
            InitializeComponent();
        }

        private void FormHapusKategori_Load(object sender, EventArgs e)
        {
            textBoxKodeKategori.MaxLength = 2;

        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data kategori akan terhapus. Apakah anda yakin ? ", " KONFIRMASI", MessageBoxButtons.YesNo);
            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                kategori kt = new kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);
                DaftarKategori daftar = new DaftarKategori();
                string hasilHapus = daftar.HapusData(kt);

                if (hasilHapus == "sukses")
                {
                    MessageBox.Show("Data kategori telah dihapus", "Info");

                    buttonKosongi_Click(buttonHapus, e);
                }
                else
                {
                    MessageBox.Show("Data kategori gagal dihapus. Pesan kesalahan : " + hasilHapus, "Kesalahan");
                }
            }
        }

        private void textBoxKodeKategori_TextChanged(object sender, EventArgs e)
        {
            if(textBoxKodeKategori.Text.Length == textBoxKodeKategori.MaxLength)
            {
                DaftarKategori daftar = new DaftarKategori();
                string hasil = daftar.CariData("KodeKategori", textBoxKodeKategori.Text);
                if(hasil=="sukses")
                {
                    if(daftar.JumlahKategoriBarang>0)
                    {
                        textBoxNamaKategori.Text = daftar.DaftarKategoriBarang[0].NamaKategori;
                        textBoxNamaKategori.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("kode kategori barang tidak ditemukan. proses hapus data tidak bisa dilakukan");
                        textBoxNamaKategori.Text = "";

                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Eror: " + hasil);

                }
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodeKategori.Text = "";
            textBoxNamaKategori.Text = "";
            textBoxKodeKategori.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {

            FormDaftarKategori frm = (FormDaftarKategori)this.Owner;
            frm.FormDaftarKategori_Load(sender, e);
            this.Close();
        }
    }
}
