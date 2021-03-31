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
    public partial class FormTambahPelanggan : Form
    {
        public FormTambahPelanggan()
        {
            InitializeComponent();
        }

        private void FormTambahPelanggan_Load(object sender, EventArgs e)
        {
            DaftarPelanggan daftar = new DaftarPelanggan();
            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                textBoxKodePelanggan.Text = daftar.KodeTerbaru;
                textBoxKodePelanggan.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Pesan kesalahan = " + hasil);
            }   
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            pelanggan p = new pelanggan(textBoxKodePelanggan.Text, textBoxNamaPelanggan.Text, textBoxAlamat.Text, textBoxTlp.Text);

            DaftarPelanggan plgn = new DaftarPelanggan();
            string hasilTambah = plgn.TambahData(p);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data pelanggan telah tersimpan", "Info");

                buttonKeluar_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data pelanggan gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
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
