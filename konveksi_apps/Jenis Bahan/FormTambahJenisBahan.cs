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
    public partial class FormTambahJenisBahan : Form
    {
        public FormTambahJenisBahan()
        {
            InitializeComponent();
        }

        private void FormTambahJenisBahan_Load(object sender, EventArgs e)
        {
            DaftarJenisBahan daftar = new DaftarJenisBahan();
            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                textBoxId.Text = daftar.KodeTerbaru;
                textBoxId.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Eror: " + hasil);
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            jenisBahan JB = new jenisBahan(textBoxId.Text, textBoxNama.Text);
            DaftarJenisBahan daftar = new DaftarJenisBahan();
            string hasilSimpan = daftar.TambahData(JB);
            if (hasilSimpan == "sukses")
            {
                MessageBox.Show("Data Jenis Bahan berhasil disimpan", "Info");

            }
            else
            {
                MessageBox.Show("Data Jenis Bahan gagal tersimpan. eror : " + hasilSimpan, "Kesalahan");

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
    }
}
