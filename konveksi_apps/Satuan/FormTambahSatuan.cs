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
    public partial class FormTambahSatuan : Form
    {
        public FormTambahSatuan()
        {
            InitializeComponent();
        }

        private void FormTambahSatuan_Load(object sender, EventArgs e)
        {
            DaftarSatuan daftar = new DaftarSatuan();
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
            satuan sa = new satuan(textBoxId.Text, textBoxNama.Text);
            DaftarSatuan daftar = new DaftarSatuan();
            string hasilSimpan = daftar.TambahData(sa);
            if (hasilSimpan == "sukses")
            {
                MessageBox.Show("Data satuan berhasil disimpan", "Info");

            }
            else
            {
                MessageBox.Show("Data satuan gagal tersimpan. eror : " + hasilSimpan, "Kesalahan");

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
            FormDaftarSatuan frm = (FormDaftarSatuan)this.Owner;
            frm.FormDaftarSatuan_Load(sender, e);
            this.Close();
        }
    }
}
