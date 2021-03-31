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
    public partial class FormDaftarJabatan : Form
    {
        public FormDaftarJabatan()
        {
            InitializeComponent();
        }

        public void FormDaftarJabatan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarJabatan daftar = new DaftarJabatan();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                dataGridViewJabatan.DataSource = daftar.ListJabatan;
            }
            else
            {
                dataGridViewJabatan.Rows.Clear();
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarJabatan daftar = new DaftarJabatan();
            string kriteria = "";
            if (comboBoxCari.Text == "Id Jabatan")
            {
                kriteria = "IdJabatan";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "Nama";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewJabatan.DataSource = daftar.ListJabatan;
                }
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJabatan frm = new FormTambahJabatan();
            frm.Owner = this;
            frm.Show();
           
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahJabatan frm = new FormUbahJabatan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusJabatan frm = new FormHapusJabatan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewJabatan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
