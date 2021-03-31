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
    public partial class FormTambahJabatan : Form
    {
        public FormTambahJabatan()
        {
            InitializeComponent();
        }

        private void FormTambahJabatan_Load(object sender, EventArgs e)
        {
            DaftarJabatan daftar = new DaftarJabatan();
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
            jabatan jab = new jabatan(textBoxId.Text, textBoxNama.Text);
            DaftarJabatan daftar = new DaftarJabatan();
            string hasilSimpan = daftar.TambahData(jab);
            if(hasilSimpan == "sukses")
            {
                MessageBox.Show("Data Jabatan berhasil disimpan", "Info");

            }
            else
            {
                MessageBox.Show("Data jabatan gagal tersimpan. eror : " + hasilSimpan, "Kesalahan");

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
