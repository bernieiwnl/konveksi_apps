using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using konveksi_apps.Form_Utama;
using KonveksiClass;
namespace konveksi_apps.Nota_Pembelian
{
    public partial class FormDaftarNotaBeli : Form
    {
        DaftarNotaBeli daftar;
        string kriteria = "";
        public FormDaftarNotaBeli()
        {
            InitializeComponent();
        }
       
        public void FormDaftarNotaBeli_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            daftar = new DaftarNotaBeli();

            string hasil = daftar.BacaSemuaDataUpdate();
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewNotaBeli.Rows.Clear();
                for (int i = 0; i < daftar.ListNotaBeliUpdate.Count; i++)
                {
                    string noNota = daftar.ListNotaBeliUpdate[i].NoNota;
                    DateTime tanggal = daftar.ListNotaBeliUpdate[i].Tanggal;
                    string namaPeg = daftar.ListNotaBeliUpdate[i].Pegawai.Nama;
                    string namaSp = daftar.ListNotaBeliUpdate[i].Supplier.NamaSupplier;
                    string alamatSp = daftar.ListNotaBeliUpdate[i].Supplier.AlamatSupplier;
                    string jenisbhn = daftar.ListNotaBeliUpdate[i].ListBeliDetil.BahanNota.Jenis_bahan.Nama_bahan;
                    string kodeBhan = daftar.ListNotaBeliUpdate[i].ListBeliDetil.BahanNota.Id;
                    string bhnnama = daftar.ListNotaBeliUpdate[i].ListBeliDetil.BahanNota.NamaBahan;
                    string warnabhn = daftar.ListNotaBeliUpdate[i].ListBeliDetil.BahanNota.Warna.Nama_warna;
                    int harga = daftar.ListNotaBeliUpdate[i].ListBeliDetil.HargaBeli;
                    int jmlhBrg = daftar.ListNotaBeliUpdate[i].ListBeliDetil.JumlahBeli;
                    int total = daftar.ListNotaBeliUpdate[i].ListBeliDetil.HargaBeli * daftar.ListNotaBeliUpdate[i].ListBeliDetil.JumlahBeli;

                    dataGridViewNotaBeli.Rows.Add(noNota, tanggal, namaPeg, namaSp, alamatSp, jenisbhn, kodeBhan, bhnnama, warnabhn, harga, jmlhBrg, total);

                }
            }
            else
            {
                MessageBox.Show("Gagal menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }

            
            

        }
        private void FormatDataGrid()
        {
            dataGridViewNotaBeli.Columns.Clear();
            dataGridViewNotaBeli.Columns.Add("NoNota", "No Nota");
            dataGridViewNotaBeli.Columns.Add("Tanggal", "Tanggal");
            dataGridViewNotaBeli.Columns.Add("NamaPegawai", "Dibuat Oleh");
            dataGridViewNotaBeli.Columns.Add("NamaSupplier", "Nama Supplier");
            dataGridViewNotaBeli.Columns.Add("AlamatSupplier", "Alamat Supplier");
            dataGridViewNotaBeli.Columns.Add("jenis_bahan", "Jenis Bahan");
            dataGridViewNotaBeli.Columns.Add("kode", "Kode Bahan");
            dataGridViewNotaBeli.Columns.Add("nama_bahan", "Nama Bahan");
            dataGridViewNotaBeli.Columns.Add("warna", "Warna");
            dataGridViewNotaBeli.Columns.Add("hargaBeli", "Harga Bahan");
            dataGridViewNotaBeli.Columns.Add("jumlahBeli", "Jumlah");
            dataGridViewNotaBeli.Columns.Add("total", "Total");

            dataGridViewNotaBeli.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["NamaSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["AlamatSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["jenis_bahan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["kode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["nama_bahan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["warna"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["hargaBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["jumlahBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaBeli frm = new FormTambahNotaBeli();
            frm.Owner = this;
            frm.Show();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            daftar = new DaftarNotaBeli();
            string kriteria = "";

            if (comboBoxCari.Text == "No Nota")
            {
                kriteria = "NB.NoNota";
            }
            else if (comboBoxCari.Text == "Tanggal")
            {
                kriteria = "NB.Tanggal";
            }
            else if (comboBoxCari.Text == "Kode Supplier")
            {
                kriteria = "Sp.KodeSupplier";
            }
            else if (comboBoxCari.Text == "Nama Supplier")
            {
                kriteria = "Sp.Nama";
            }
            else if (comboBoxCari.Text == "Alamat Supplier")
            {
                kriteria = "Sp.Alamat";
            }
            else if (comboBoxCari.Text == "Kode Pegawai")
            {
                kriteria = "Pg.KodePegawai";
            }
            else if (comboBoxCari.Text == "Nama Pegawai")
            {
                kriteria = "Pg.Nama";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewNotaBeli.Rows.Clear();

                for (int i = 0; i < daftar.JumlahNotaBeli; i++)
                {
                    string noNota = daftar.ListNotaBeli[i].NoNota;
                    DateTime tanggal = daftar.ListNotaBeli[i].Tanggal;
                    string kodeSp = daftar.ListNotaBeli[i].Supplier.KodeSupplier;
                    string namaSp = daftar.ListNotaBeli[i].Supplier.NamaSupplier;
                    string alamatSp = daftar.ListNotaBeli[i].Supplier.AlamatSupplier;
                    string kodePg = daftar.ListNotaBeli[i].Pegawai.KodePegawai;
                    string namaPg = daftar.ListNotaBeli[i].Pegawai.Nama;
                    int jmlhBrg = daftar.ListNotaBeli[i].JumlahBarangNota;
                    dataGridViewNotaBeli.Rows.Add(noNota, tanggal, kodeSp, namaSp, alamatSp, kodePg, namaPg, jmlhBrg);
                }
            }
            else
            {
                MessageBox.Show("Gagal mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            daftar.CetakNota(kriteria, textBoxCari.Text, "daftar_nota_beli.txt");

            MessageBox.Show("Daftar nota beli telah tercetak");
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCari.Text == "No Nota")
            {
                kriteria = "NB.NoNota";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Tanggal")
            {
                kriteria = "NB.Tanggal";
                dateTimePickerNota.Visible = true;
                textBoxCari.Visible = false;
            }
            else if (comboBoxCari.Text == "Kode Supplier")
            {
                kriteria = "Sp.KodeSupplier";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Nama Supplier")
            {
                kriteria = "Sp.Nama";
                dateTimePickerNota.Visible = false;
                textBoxCari.Visible = true;
            }
            else if (comboBoxCari.Text == "Alamat Supplier")
            {
                kriteria = "Sp.Alamat";
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
            daftar = new DaftarNotaBeli();
            string hasil = daftar.CariData("NB.Tanggal", dateTimePickerNota.Value.ToString("yyyy-MM-dd hh:mm:ss"));
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewNotaBeli.Rows.Clear();

                for (int i = 0; i < daftar.JumlahNotaBeli; i++)
                {
                    string noNota = daftar.ListNotaBeli[i].NoNota;
                    DateTime tanggal = daftar.ListNotaBeli[i].Tanggal;
                    string kodeSp = daftar.ListNotaBeli[i].Supplier.KodeSupplier;
                    string namaSp = daftar.ListNotaBeli[i].Supplier.NamaSupplier;
                    string alamatSp = daftar.ListNotaBeli[i].Supplier.AlamatSupplier;
                    string kodePg = daftar.ListNotaBeli[i].Pegawai.KodePegawai;
                    string namaPg = daftar.ListNotaBeli[i].Pegawai.Nama;
                    int jmlhBrg = daftar.ListNotaBeli[i].JumlahBarangNota;
                    dataGridViewNotaBeli.Rows.Add(noNota, tanggal, kodeSp, namaSp, alamatSp, kodePg, namaPg, jmlhBrg);
                }
            }
            else
            {
                MessageBox.Show("Gagal mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }
    }
}
