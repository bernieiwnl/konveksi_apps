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
namespace konveksi_apps.Pelanggan
{
    public partial class FormDaftarPelanggan : Form
    {
        public FormDaftarPelanggan()
        {
            InitializeComponent();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarPelanggan daftar = new DaftarPelanggan();
            string kriteria = "";
            if (comboBoxCari.Text == "Kode Pelanggan")
            {
                kriteria = "KodePelanggan";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "Nama";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "Alamat";
            }
            else if (comboBoxCari.Text == "Telepon")
            {
                kriteria = "Telepon";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewPelanggan.DataSource = daftar.ListPelanggan;
                }
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewPelanggan.Columns.Clear();
            dataGridViewPelanggan.Columns.Add("KodePelanggan", "Kode Pelanggan");
            dataGridViewPelanggan.Columns.Add("Nama", "Nama Pelanggan");
            dataGridViewPelanggan.Columns.Add("Telepon", "Telepon");
            dataGridViewPelanggan.Columns.Add("Alamat", "Alamat");

            dataGridViewPelanggan.Columns["KodePelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["Telepon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        public void FormDaftarPelanggan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarPelanggan daftar = new DaftarPelanggan();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                FormatDataGrid();
                dataGridViewPelanggan.Rows.Clear();
                for (int i = 0; i < daftar.JumlahPelanggan; i++)
                {
                    string kode = daftar.ListPelanggan[i].KodePelanggan;
                    string nama = daftar.ListPelanggan[i].NamaPelanggan;
                    string telepon = daftar.ListPelanggan[i].Telepon;
                    string Alamat = daftar.ListPelanggan[i].Alamat;
                   
                    dataGridViewPelanggan.Rows.Add(kode, nama, telepon, Alamat);
                }

            }
            else
            {
                MessageBox.Show("Gagal menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPelanggan frm = new FormTambahPelanggan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPelanggan frm = new FormUbahPelanggan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPelanggan frm = new FormHapusPelanggan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
