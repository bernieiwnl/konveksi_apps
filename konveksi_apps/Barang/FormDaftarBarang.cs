using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using konveksi_apps.Barang;
using KonveksiClass;
namespace konveksi_apps
{
    public partial class FormDaftarBarang : Form
    {
        public FormDaftarBarang()
        {
            InitializeComponent();
        }
        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("NamaBarang", "Nama");
            dataGridViewBarang.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewBarang.Columns.Add("Stok", "Stok");
            dataGridViewBarang.Columns.Add("NamaKategori", "Kategori");
            dataGridViewBarang.Columns.Add("minimal", "Minimal Pembelian");

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
            dataGridViewBarang.Columns["minimal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void DaftarBarang_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarBarang daftar = new DaftarBarang();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewBarang.Rows.Clear();

                for (int i = 0; i < daftar.JumlahBarang; i++)
                {
                    string kode = daftar.ListBarang[i].KodeBarang;
                    string nama = daftar.ListBarang[i].NamaBarang;
                    int harga = daftar.ListBarang[i].HargaJual;
                    int stok = daftar.ListBarang[i].Stok;
                    string namaK = daftar.ListBarang[i].KategoriBarang.NamaKategori;
                    string minimal = daftar.ListBarang[i].Minimal + " " + daftar.ListBarang[i].Satuan.NamaSatuan;
                    dataGridViewBarang.Rows.Add(kode, nama, harga, stok, namaK, minimal);

                    if(stok <0)
                    {
                        MessageBox.Show("Ada stok barang yang kosong, Segera lakukan pembelian");

                    }
                }
            }
            else
            {
                MessageBox.Show("Gagal menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }

        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarBarang daftar = new DaftarBarang();
            string kriteria = "";

            if (comboBoxCari.Text == "Kode Barang")
            {
                kriteria = "B.KodeBarang";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "B.Nama";
            }
            else if (comboBoxCari.Text == "Harga Jual")
            {
                kriteria = "B.HargaJual";
            }
            else if (comboBoxCari.Text == "Stok")
            {
                kriteria = "B.Stok";
            }
            else if (comboBoxCari.Text == "Kode Kategori")
            {
                kriteria = "K.Nama";
            }


            string hasil = daftar.CariData(kriteria, textBoxCari.Text);

            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewBarang.Rows.Clear();

                for (int i = 0; i < daftar.JumlahBarang; i++)
                {
                    string kode = daftar.ListBarang[i].KodeBarang;
                    string nama = daftar.ListBarang[i].NamaBarang;
                    int harga = daftar.ListBarang[i].HargaJual;
                    int stok = daftar.ListBarang[i].Stok;
                   
                    string namaK = daftar.ListBarang[i].KategoriBarang.NamaKategori;
                    dataGridViewBarang.Rows.Add(kode, nama, harga, stok, namaK);
                }
            }
            else
            {
                MessageBox.Show("Gagal mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahBarang frm = new FormTambahBarang();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahBarang frm = new FormUbahBarang();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusBarang frm = new FormHapusBarang();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
