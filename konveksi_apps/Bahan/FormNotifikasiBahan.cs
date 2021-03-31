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

namespace konveksi_apps.Barang
{
    public partial class FormNotifikasiBahan : Form
    {
        public FormNotifikasiBahan()
        {
            InitializeComponent();
        }

        private void FormNotifikasiBahan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarBahan daftar = new DaftarBahan();

            string hasil = daftar.BacaSemuaDataStock();
            if (hasil == "sukses")
            {
                dataGridViewBahan.DataSource = daftar.ListBahan;
            }
            else
            {
                dataGridViewBahan.Rows.Clear();
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarBahan daftar = new DaftarBahan();
            string kriteria = "";
            if (comboBoxCari.Text == "Id Bahan")
            {
                kriteria = "id";
            }
            else if (comboBoxCari.Text == "Nama Bahan")
            {
                kriteria = "namaBahan";
            }
            else if (comboBoxCari.Text == "Harga")
            {
                kriteria = "hargaBeli";
            }
            else if (comboBoxCari.Text == "Stok")
            {
                kriteria = "stok";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewBahan.DataSource = daftar.ListBahan;
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
