using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using konveksi_apps;
using KonveksiClass;

namespace konveksi_apps.Kegiatan
{
    public partial class FormDaftarKegiatan : Form
    {
        public FormDaftarKegiatan()
        {
            InitializeComponent();
        }

        public void FormDaftarKegiatan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarKegiatan daftar = new DaftarKegiatan();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                dataGridViewKegiatan.DataSource = daftar.ListKegiatan;
            }
            else
            {
                dataGridViewKegiatan.Rows.Clear();
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahKegiatan frm = new FormTambahKegiatan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahKegiatan frm = new FormUbahKegiatan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusKegiatan frm = new FormHapusKegiatan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarKegiatan daftar = new DaftarKegiatan();
            string kriteria = "";
            if (comboBoxCari.Text == "Id Kegiatan")
            {
                kriteria = "idKegiatan";
            }
            else if (comboBoxCari.Text == "Nama Kegiatan")
            {
                kriteria = "namaKegiatan";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewKegiatan.DataSource = daftar.ListKegiatan;
                }
            }
        }
    }
}
