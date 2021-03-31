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
    public partial class FormDaftarNotaJual : Form
    {
        DaftarNotaJual daftar;
        string kriteria = "";
        public FormDaftarNotaJual()
        {
            InitializeComponent();
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


        public void FormDaftarNotaJual_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            daftar = new DaftarNotaJual();

            string hasil = daftar.BacaSemuaData();
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

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            daftar = new DaftarNotaJual();
            string kriteria = "";

            if (comboBoxCari.Text == "No Nota")
            {
                kriteria = "N.NoNota";
                dateTimePickerNota.Visible = false;
            }
            else if (comboBoxCari.Text == "Tanggal")
            {
                kriteria = "N.Tanggal";
                dateTimePickerNota.Visible = true;

            }
            else if (comboBoxCari.Text == "Tanggal Selesai")
            {
                kriteria = "N.tanggalSelesai";
                dateTimePickerNota.Visible = false;
            }
            else if (comboBoxCari.Text == "Status")
            {
                kriteria = "N.Status";
                dateTimePickerNota.Visible = false;
            }
            else if (comboBoxCari.Text == "Kode Pelanggan")
            {
                kriteria = "Plg.KodePelanggan";
                dateTimePickerNota.Visible = false;
            }
            else if (comboBoxCari.Text == "Nama Pelanggan")
            {
                kriteria = "Plg.Nama";
                dateTimePickerNota.Visible = false;
            }
            else if (comboBoxCari.Text == "Alamat Pelanggan")
            {
                kriteria = "Plg.Alamat";
                dateTimePickerNota.Visible = false;
            }
            else if (comboBoxCari.Text == "Kode Pegawai")
            {
                kriteria = "Pg.KodePegawai";
                dateTimePickerNota.Visible = false;
            }
            else if (comboBoxCari.Text == "Nama Pegawai")
            {
                kriteria = "Pg.Nama";
                dateTimePickerNota.Visible = false;
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
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
                    string kodePlg = daftar.ListNotaJual[i].Pelanggan.KodePelanggan;
                    string namaPlg = daftar.ListNotaJual[i].Pelanggan.NamaPelanggan;
                    string alamatPlg = daftar.ListNotaJual[i].Pelanggan.Alamat;
                    string kodePg = daftar.ListNotaJual[i].Pegawai.KodePegawai;
                    string namaPg = daftar.ListNotaJual[i].Pegawai.Nama;
                    int jmlhBrg = daftar.ListNotaJual[i].JumlahBarangNota;
                    dataGridViewNotaJual.Rows.Add(noNota, tanggal, tglSelesai, status, kodePlg, namaPlg, alamatPlg, kodePg, namaPg, jmlhBrg);
                }
            }
            else
            {
                MessageBox.Show("Gagal mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaJual frm = new FormTambahNotaJual();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            daftar.CetakNota(kriteria, textBoxCari.Text, "daftar_nota_jual_UD.Konveksi.txt");

            MessageBox.Show("Daftar nota jual telah tercetak");
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUbahNotaJual frm = new FormUbahNotaJual();
            frm.Owner = this;
            frm.Show();
        }

        private void comboBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCari.Text == "No Nota")
            {
                kriteria = "N.NoNota";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Tanggal")
            {
                kriteria = "N.Tanggal";
                dateTimePickerNota.Visible = true;
                textBoxCari.Visible = false;

            }
            else if (comboBoxCari.Text == "Tanggal Selesai")
            {
                kriteria = "N.tanggalSelesai";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Status")
            {
                kriteria = "N.Status";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Kode Pelanggan")
            {
                kriteria = "Plg.KodePelanggan";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Nama Pelanggan")
            {
                kriteria = "Plg.Nama";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Alamat Pelanggan")
            {
                kriteria = "Plg.Alamat";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Kode Pegawai")
            {
                kriteria = "Pg.KodePegawai";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Nama Pegawai")
            {
                kriteria = "Pg.Nama";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
        }

        private void dateTimePickerNota_ValueChanged(object sender, EventArgs e)
        {
            daftar = new DaftarNotaJual();
            string hasil = daftar.CariData("N.Tanggal", dateTimePickerNota.Value.ToString("yyyy-MM-dd hh:mm:ss"));
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
                    string kodePlg = daftar.ListNotaJual[i].Pelanggan.KodePelanggan;
                    string namaPlg = daftar.ListNotaJual[i].Pelanggan.NamaPelanggan;
                    string alamatPlg = daftar.ListNotaJual[i].Pelanggan.Alamat;
                    string kodePg = daftar.ListNotaJual[i].Pegawai.KodePegawai;
                    string namaPg = daftar.ListNotaJual[i].Pegawai.Nama;
                    int jmlhBrg = daftar.ListNotaJual[i].JumlahBarangNota;
                    dataGridViewNotaJual.Rows.Add(noNota, tanggal, tglSelesai, status, kodePlg, namaPlg, alamatPlg, kodePg, namaPg, jmlhBrg);
                }
            }
            else
            {
                MessageBox.Show("Gagal mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }
    }
}
