using konveksi_apps.Form_Utama;
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

namespace konveksi_apps.Pekerjaan
{
    public partial class FormDaftarPekerjaan : Form
    {
        DaftarPekerjaan daftar;
        public FormDaftarPekerjaan()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPekerjaan frm = new FormTambahPekerjaan();
            frm.Owner = this;
            frm.Show();
        }
       

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPekerjaan frm = new FormUbahPekerjaan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPekerjaan frm = new FormHapusPekerjaan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            dataGridViewPekerjaan.Columns.Clear();

            dataGridViewPekerjaan.Columns.Add("idPengerjaan", "ID");
            dataGridViewPekerjaan.Columns.Add("namaKegiatan", "Nama Kegiatan");
            dataGridViewPekerjaan.Columns.Add("namaPegawai", "Nama Pegawai");
            dataGridViewPekerjaan.Columns.Add("tanggalPengerjaan", "Tanggal");
            dataGridViewPekerjaan.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewPekerjaan.Columns.Add("Nama", "Nama Barang");
            dataGridViewPekerjaan.Columns.Add("harga", "Harga");
            dataGridViewPekerjaan.Columns.Add("satuan", "Satuan");
            dataGridViewPekerjaan.Columns.Add("total", "Total");
            dataGridViewPekerjaan.Columns.Add("keterangan", "Keterangan");
            dataGridViewPekerjaan.Columns.Add("status", "status");
           

            dataGridViewPekerjaan.Columns["idPengerjaan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["namaKegiatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["namaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["satuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPekerjaan.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }


        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
          daftar = new DaftarPekerjaan();
            string kriteria = "";

            if (comboBoxCari.Text == "Nama Pegawai")
            {
                kriteria = "peg.KodeBarang";
            }
            else if (comboBoxCari.Text == "Nama Kegiatan")
            {
                kriteria = "k.namaKegiatan";
            }
            else if (comboBoxCari.Text == "Kode Barang")
            {
                kriteria = "b.KodeBarang";
            }
            else if (comboBoxCari.Text == "Nama Barang")
            {
                kriteria = "b.Nama";
            }
            else if (comboBoxCari.Text == "Keterangan")
            {
                kriteria = "p.Keterangan";
            }
            else if (comboBoxCari.Text == "ID Gaji")
            {
                kriteria = "p.idPengerjaan";
            }
            else if (comboBoxCari.Text == "Status")
            {
                kriteria = "p.status";
            }

   

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);

            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewPekerjaan.Rows.Clear();

                for (int i = 0; i < daftar.JumlahPekerjaan; i++)
                {
                    string idPengerjaan = daftar.ListPekerjaan[i].IdPengerjaan;
                    string namaKegiatan = daftar.ListPekerjaan[i].Kegiatan.NamaKegiatan;
                    string namaPegawai = daftar.ListPekerjaan[i].Pegawai.Nama;
                    string tanggalPengerjaan = daftar.ListPekerjaan[i].TanggalKegiatan.ToString("dddd, dd MMMM yyyy");
                    string kodeBarang = daftar.ListPekerjaan[i].Barang.KodeBarang;
                    string namaBarang = daftar.ListPekerjaan[i].Barang.NamaBarang;
                    string harga = daftar.ListPekerjaan[i].Harga.ToString();
                    string satuan = daftar.ListPekerjaan[i].Satuan.ToString();
                    int totalharga = daftar.ListPekerjaan[i].Harga * daftar.ListPekerjaan[i].Satuan;
                    string total = totalharga.ToString();
                    string keterangan = daftar.ListPekerjaan[i].Keterangan;
                    string status = daftar.ListPekerjaan[i].Status;

                    dataGridViewPekerjaan.Rows.Add(idPengerjaan, namaKegiatan, namaPegawai, tanggalPengerjaan, kodeBarang, namaBarang, harga, satuan, total, keterangan, status);
                }
            }
            else
            {
                MessageBox.Show("Gagal mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        public void FormDaftarPekerjaan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;
    

            daftar = new DaftarPekerjaan();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewPekerjaan.Rows.Clear();

                for (int i = 0; i < daftar.JumlahPekerjaan; i++)
                {
                    string idPengerjaan = daftar.ListPekerjaan[i].IdPengerjaan;
                    string namaKegiatan = daftar.ListPekerjaan[i].Kegiatan.NamaKegiatan;
                    string namaPegawai = daftar.ListPekerjaan[i].Pegawai.Nama;
                    string tanggalPengerjaan = daftar.ListPekerjaan[i].TanggalKegiatan.ToString("dddd, dd MMMM yyyy");
                    string kodeBarang = daftar.ListPekerjaan[i].Barang.KodeBarang;
                    string namaBarang = daftar.ListPekerjaan[i].Barang.NamaBarang;
                    string harga = daftar.ListPekerjaan[i].Harga.ToString();
                    string satuan = daftar.ListPekerjaan[i].Satuan.ToString();
                    int totalharga = daftar.ListPekerjaan[i].Harga * daftar.ListPekerjaan[i].Satuan;
                    string total = totalharga.ToString();
                    string keterangan = daftar.ListPekerjaan[i].Keterangan;
                    string status = daftar.ListPekerjaan[i].Status;

                    dataGridViewPekerjaan.Rows.Add(idPengerjaan, namaKegiatan, namaPegawai, tanggalPengerjaan, kodeBarang, namaBarang, harga, satuan, total, keterangan, status);
                }
            }
            else
            {
                MessageBox.Show("Gagal menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            daftar.CetakNota(comboBoxCari.Text, textBoxCari.Text, "daftar_gaji.txt");

            MessageBox.Show("Daftar nota beli telah tercetak");
        }
    }
}
