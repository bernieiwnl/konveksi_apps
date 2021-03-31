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
    public partial class FormDaftarJenisBahan : Form
    {
        public FormDaftarJenisBahan()
        {
            InitializeComponent();
        }

        public void FormDaftarJenisBahan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarJenisBahan daftar = new DaftarJenisBahan();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                dataGridViewJenisBahan.DataSource = daftar.ListJenisBahan;
            }
            else
            {
                dataGridViewJenisBahan.Rows.Clear();
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarJenisBahan daftar = new DaftarJenisBahan();
            string kriteria = "";
            if (comboBoxCari.Text == "Id Bahan")
            {
                kriteria = "id";
            }
            else if (comboBoxCari.Text == "Nama Bahan")
            {
                kriteria = "nama_bahan";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewJenisBahan.DataSource = daftar.ListJenisBahan;
                }
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJenisBahan frm = new FormTambahJenisBahan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahJenisBahan frm = new FormUbahJenisBahan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusJenisBahan frm = new FormHapusJenisBahan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
