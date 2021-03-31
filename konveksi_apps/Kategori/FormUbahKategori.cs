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
    public partial class FormUbahKategori : Form
    {
        public FormUbahKategori()
        {
            InitializeComponent();
        }

        private void FormUbahKategori_Load(object sender, EventArgs e)
        {
            textBoxKodeKategori.MaxLength = 2;
        }

        private void textBoxKodeKategori_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodeKategori.Text.Length == textBoxKodeKategori.MaxLength)
            {
                DaftarKategori daftar = new DaftarKategori();
                string hasil = daftar.CariData("KodeKategori", textBoxKodeKategori.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahKategoriBarang > 0)
                    {
                        textBoxNamaKategori.Text = daftar.DaftarKategoriBarang[0].NamaKategori;
                        textBoxNamaKategori.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode kategori tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
                        textBoxNamaKategori.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankkan. Pesan kesalahan = " + hasil);
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            kategori kt = new kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);
            DaftarKategori daftar = new DaftarKategori();
            string hasilTambah = daftar.UbahData(kt);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data kategori telah diubah", "Info");

                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data kategori gagal diubah. Pesan kesalahan : " + hasilTambah, "Kesalahan");
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
