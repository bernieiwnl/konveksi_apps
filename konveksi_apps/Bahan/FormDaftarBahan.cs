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

namespace konveksi_apps.Bahan
{
    public partial class FormDaftarBahan : Form
    {
        public FormDaftarBahan()
        {
            InitializeComponent();
        }

        public void FormDaftarBahan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarBahan daftar = new DaftarBahan();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewBahan.Rows.Clear();

                for (int i = 0; i < daftar.JumlahBahan; i++)
                {
                    string id = daftar.ListBahan[i].Id;
                    string namaBahan = daftar.ListBahan[i].NamaBahan;
                    string nama_warna = daftar.ListBahan[i].Warna.Nama_warna;
                    int stok = daftar.ListBahan[i].Stok;
                    string nama_bahan = daftar.ListBahan[i].Jenis_bahan.Nama_bahan;
                    int hargaBeli = daftar.ListBahan[i].HargaBeli;
                    string minimal = daftar.ListBahan[i].Minimal + " " + daftar.ListBahan[i].Satuan.NamaSatuan;
                    dataGridViewBahan.Rows.Add(id, namaBahan, nama_warna, stok, nama_bahan, hargaBeli, minimal);

                    if (stok < 0)
                    {
                        MessageBox.Show("Ada stok bahan yang kosong, Segera lakukan pembelian");

                    }
                }
            }
            else
            {
                dataGridViewBahan.Rows.Clear();
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUpdateBahan frm = new FormUpdateBahan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahBahan frm = new FormTambahBahan();
            frm.Owner = this;
            frm.Show();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarBahan daftar = new DaftarBahan();
            string kriteria = "";
            if (comboBoxCari.Text == "Id Bahan")
            {
                kriteria = "barang.id";
            }
            else if (comboBoxCari.Text == "Nama Bahan")
            {
                kriteria = "barang.namaBahan";
            }
            else if (comboBoxCari.Text == "Harga")
            {
                kriteria = "barang.hargaBeli";
            }
            else if (comboBoxCari.Text == "Stok")
            {
                kriteria = "barang.stok";
            }
            else if (comboBoxCari.Text == "Jenis Bahan")
            {
                kriteria = "jb.nama_bahan";
            }
            else if (comboBoxCari.Text == "Warna")
            {
                kriteria = "w.nama_warna";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            {
                if (hasil == "sukses")
                {
                    dataGridViewBahan.DataSource = daftar.ListBahan;
                }
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusBahan frm = new FormHapusBahan();
            frm.Owner = this;
            frm.Show();
        }

        private void FormatDataGrid()
        {
            dataGridViewBahan.Columns.Clear();

            dataGridViewBahan.Columns.Add("id", "Kode Bahan");
            dataGridViewBahan.Columns.Add("namaBahan", "Nama Bahan");
            dataGridViewBahan.Columns.Add("nama_warna", "Warna Bahan");
            dataGridViewBahan.Columns.Add("Stok", "Stok");
            dataGridViewBahan.Columns.Add("nama_bahan", "Jenis Bahan");
            dataGridViewBahan.Columns.Add("hargaBeli", "Harga Beli");
            dataGridViewBahan.Columns.Add("minimal", "Minimal Pembelian");

            dataGridViewBahan.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahan.Columns["namaBahan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahan.Columns["nama_warna"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahan.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahan.Columns["nama_bahan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahan.Columns["hargaBeli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBahan.Columns["hargaBeli"].DefaultCellStyle.Format = "0,###";
            dataGridViewBahan.Columns["minimal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
