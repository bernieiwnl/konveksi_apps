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
    public partial class FormNotifikasiBarang : Form
    {
        public FormNotifikasiBarang()
        {
            InitializeComponent();
        }

        private void FormNotifikasiBarang_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarBarang daftar = new DaftarBarang();

            string hasil = daftar.BacaSemuaDataStock();
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

                    if (stok < 0)
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

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("NamaBarang", "Nama");
            dataGridViewBarang.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewBarang.Columns.Add("Stok", "Stok");
            dataGridViewBarang.Columns.Add("NamaKategori", "Kategori");

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
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


            string hasil = daftar.CariDataStock(kriteria, textBoxCari.Text);

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

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarBarang frm = new FormDaftarBarang();
            frm.Owner = this;
            frm.Show();
        }
    }
}
