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
namespace konveksi_apps.Supplier
{
    public partial class FormDaftarSupplier : Form
    {
        public FormDaftarSupplier()
        {
            InitializeComponent();
        }

        public void FormDaftarSupplier_Load(object sender, EventArgs e)
        {
            buttonHapus.Visible = false;
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarSupplier daftar = new DaftarSupplier();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                dataGridViewSupplier.DataSource = daftar.ListSupplier;
            }
            else
            {
                dataGridViewSupplier.Rows.Clear();
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarSupplier daftar = new DaftarSupplier();
            string kriteria = "";
            if (comboBoxCari.Text == "Kode Supplier")
            {
                kriteria = "KodeSupplier";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "Nama";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "Alamat";
            }
            else if( comboBoxCari.Text == "Jenis Suplier")
            {
                kriteria = "jenisSuplier";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewSupplier.DataSource = daftar.ListSupplier;
                }
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahSupplier frm = new FormTambahSupplier();
            frm.Owner = this;
            frm.Show();
            
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahSupplier frm = new FormUbahSupplier();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusSupplier frm = new FormHapusSupplier();
            frm.Owner = this;
            frm.Show();
           
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
