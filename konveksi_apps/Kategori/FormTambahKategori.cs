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
    public partial class FormTambahKategori : Form
    {
        public FormTambahKategori()
        {
            InitializeComponent();
        }

        private void FormTambahKategori_Load(object sender, EventArgs e)
        {
            DaftarKategori daftar = new DaftarKategori();
            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                textBoxKodeKategori.Text = daftar.KodeTerbaru;
                textBoxKodeKategori.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Pesan kesalahan = " + hasil);
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            kategori kat = new kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);
            DaftarKategori daftar = new DaftarKategori();
            string hasilSimpan = daftar.TambahData(kat);
            if(hasilSimpan == "sukses")
            {
                MessageBox.Show("Data Kategori Barang berhasil disimpan", "info");
                buttonKeluar_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data Kategori barang gagal tersimpan. Eror: " + hasilSimpan, "kesalahan");
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
