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
    public partial class FormDaftarKategori : Form
    {
        public FormDaftarKategori()
        {
            InitializeComponent();
        }

        public void FormDaftarKategori_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;
            DaftarKategori daftar = new DaftarKategori();
            string hasil = daftar.BacaSemuaData();
            if(hasil == "sukses")
            {
                dataGridViewBarang.DataSource = daftar.DaftarKategoriBarang;

            }
            else
            {
                dataGridViewBarang.Rows.Clear();
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahKategori frm = new FormTambahKategori();
            frm.Owner = this;
            frm.Show();
            
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahKategori frm = new FormUbahKategori();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusKategori frm = new FormHapusKategori();
            frm.Owner = this;
            frm.Show();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarKategori daftar = new DaftarKategori();
            string kriteria = "";
            if (comboBoxCari.Text == "Kode Kategori")
            {
                kriteria = "KodeKategori";
            }
            else if (comboBoxCari.Text == "Nama Kategori")
            {
                kriteria = "Nama";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewBarang.DataSource = daftar.DaftarKategoriBarang;
                }
            }
        }
    }
}
