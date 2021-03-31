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
namespace konveksi_apps.Pelanggan
{
    public partial class FormUbahPelanggan : Form
    {
        public FormUbahPelanggan()
        {
            InitializeComponent();
        }

        private void FormUbahPelanggan_Load(object sender, EventArgs e)
        {
            textBoxKodePelanggan.MaxLength = 1;

        }

        private void textBoxKodePelanggan_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodePelanggan.Text.Length == textBoxKodePelanggan.MaxLength)
            {
                DaftarPelanggan daftar = new DaftarPelanggan();
                string hasil = daftar.CariData("KodePelanggan", textBoxKodePelanggan.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahPelanggan > 0)
                    {
                        textBoxNamaPelanggan.Text = daftar.ListPelanggan[0].NamaPelanggan;
                        textBoxAlamat.Text = daftar.ListPelanggan[0].Alamat;
                        textBoxTlp.Text = daftar.ListPelanggan[0].Telepon;
                        textBoxNamaPelanggan.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode Pelangan tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
                        textBoxNamaPelanggan.Text = "";
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
            pelanggan p = new pelanggan(textBoxKodePelanggan.Text, textBoxNamaPelanggan.Text, textBoxAlamat.Text, textBoxTlp.Text);
            DaftarPelanggan langgan = new DaftarPelanggan();
            string hasilTambah = langgan.UbahData(p);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data pelanggan telah diubah", "Info");

                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data pelanggan gagal diubah. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodePelanggan.Text = "";
            textBoxNamaPelanggan.Text = "";
            textBoxAlamat.Text = "";
            textBoxTlp.Text = "";

            textBoxKodePelanggan.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPelanggan frm = (FormDaftarPelanggan)this.Owner;
            frm.FormDaftarPelanggan_Load(sender, e);
            this.Close();
        }
    }
}
