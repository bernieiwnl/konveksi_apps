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
namespace konveksi_apps.Nota_Penjualan
{
    public partial class FormNotifikasiNotaJual : Form
    {
        DaftarNotaJual daftar;
        public FormNotifikasiNotaJual()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void FormatDataGrid()
        {
            dataGridViewNotaJual.Columns.Clear();

            dataGridViewNotaJual.Columns.Add("NoNota", "No Nota");
            dataGridViewNotaJual.Columns.Add("Tanggal", "Tanggal");
            dataGridViewNotaJual.Columns.Add("TanggalSelesai", "Tanggal Selesai");
            dataGridViewNotaJual.Columns.Add("Status", "Status");

            dataGridViewNotaJual.Columns.Add("KodePelanggan", "Kode Pelanggan");
            dataGridViewNotaJual.Columns.Add("NamaPelanggan", "Nama Pelanggan");
            dataGridViewNotaJual.Columns.Add("Alamat", "Alamat Pelanggan");
            dataGridViewNotaJual.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridViewNotaJual.Columns.Add("NamaPegawai", "Nama Pegawai");
            dataGridViewNotaJual.Columns.Add("JumlahBarang", "Jumlah Barang");

            dataGridViewNotaJual.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["TanggalSelesai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNotaJual.Columns["KodePelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["NamaPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["JumlahBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void FormNotifikasiNotaJual_Load(object sender, EventArgs e)
        {
            daftar = new DaftarNotaJual();

            string hasil = daftar.TampilNota();
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewNotaJual.Rows.Clear();
                for (int i = 0; i < daftar.JumlahNotaJual; i++)
                {
                    string noNota = daftar.ListNotaJual[i].NoNota;
                    DateTime tanggal = daftar.ListNotaJual[i].Tanggal;
                    DateTime tglSelesai = daftar.ListNotaJual[i].TanggalSelesai;
                    string status = daftar.ListNotaJual[i].Status;
                    string noPlg = daftar.ListNotaJual[i].Pelanggan.KodePelanggan;
                    string namaPlg = daftar.ListNotaJual[i].Pelanggan.NamaPelanggan;
                    string alamatPlg = daftar.ListNotaJual[i].Pelanggan.Alamat;
                    string kodePeg = daftar.ListNotaJual[i].Pegawai.KodePegawai;
                    string namaPeg = daftar.ListNotaJual[i].Pegawai.Nama;
                    int jmlhBrg = daftar.ListNotaJual[i].JumlahBarangNota;

                    dataGridViewNotaJual.Rows.Add(noNota, tanggal, tglSelesai, status, noPlg, namaPlg, alamatPlg, kodePeg, namaPeg, jmlhBrg);
                }
            }
            else
            {
                MessageBox.Show("Gagal menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarNotaJual frm = new FormDaftarNotaJual();
            frm.Owner = this;
            frm.Show();
        }
    }
}
