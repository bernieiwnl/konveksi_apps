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
    public partial class FormDaftarSatuan : Form
    {
        public FormDaftarSatuan()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahSatuan frm = new FormTambahSatuan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUpdateSatuan frm = new FormUpdateSatuan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusSatuan frm = new FormHapusSatuan();
            frm.Owner = this;
            frm.Show();
        }

        public void FormDaftarSatuan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarSatuan daftar = new DaftarSatuan();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                dataGridViewSatuan.DataSource = daftar.Satuans;
            }
            else
            {
                dataGridViewSatuan.Rows.Clear();
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarSatuan daftar = new DaftarSatuan();
            string kriteria = "";
            if (comboBoxCari.Text == "Id")
            {
                kriteria = "id";
            }
            else if (comboBoxCari.Text == "Nama Satuan")
            {
                kriteria = "namaSatuan";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewSatuan.DataSource = daftar.Satuans;
                }
            }
        }
    }
}
