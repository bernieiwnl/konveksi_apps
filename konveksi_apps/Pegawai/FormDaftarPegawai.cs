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
namespace konveksi_apps.Pegawai
{
    public partial class FormDaftarPegawai : Form
    {
        public FormDaftarPegawai()
        {
            InitializeComponent();
        }

        public void FormDaftarPegawau_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarPegawai daftar = new DaftarPegawai();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewPegawai.Rows.Clear();

                for (int i = 0; i < daftar.JumlahPegawai; i++)
                {
                    string kode = daftar.ListPegawai[i].KodePegawai;
                    string nama = daftar.ListPegawai[i].Nama;
                    string tgl = daftar.ListPegawai[i].TanggalLahir;
                    string alamat = daftar.ListPegawai[i].Alamat;
                    string gaji = daftar.ListPegawai[i].Gaji;
                    string user = daftar.ListPegawai[i].Username;
                    string pass = daftar.ListPegawai[i].Password;

                    string namaJ = daftar.ListPegawai[i].JabatanPegawai.NamaJabatan;
                    dataGridViewPegawai.Rows.Add(kode, nama, tgl, alamat, gaji, user, pass, namaJ);
                }
            }
            else
            {
                MessageBox.Show("Gagal menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }
        private void FormatDataGrid()
        {
            dataGridViewPegawai.Columns.Clear();

            dataGridViewPegawai.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridViewPegawai.Columns.Add("Nama", "Nama Pegawai");
            dataGridViewPegawai.Columns.Add("TglLahir", "Tanggal Lahir");
            dataGridViewPegawai.Columns.Add("Alamat", "Alamat");
            dataGridViewPegawai.Columns.Add("Gaji", "Gaji");
            dataGridViewPegawai.Columns.Add("Username", "Username");
            dataGridViewPegawai.Columns.Add("Password", "Password");
            dataGridViewPegawai.Columns.Add("NamaJabatan", "Jabatan");

            dataGridViewPegawai.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["TglLahir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Password"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["NamaJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPegawai.Columns["Gaji"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewPegawai.Columns["Gaji"].DefaultCellStyle.Format = "0,###";
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarPegawai daftar = new DaftarPegawai();
            string kriteria = "";

            if (comboBoxCari.Text == "Kode Pegawai")
            {
                kriteria = "pg.KodePegawai";
            }
            else if (comboBoxCari.Text == "Nama Pegawai")
            {
                kriteria = "pg.Nama";
            }
            else if (comboBoxCari.Text == "Tanggal Lahir")
            {
                kriteria = "pg.TglLahir";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "pg.Alamat";
            }
            else if (comboBoxCari.Text == "Gaji")
            {
                kriteria = "pg.Gaji";
            }
            else if (comboBoxCari.Text == "Username")
            {
                kriteria = "pg.Username";
            }
            else if (comboBoxCari.Text == "Password")
            {
                kriteria = "pg.Password";
            }
            else if (comboBoxCari.Text == "Id Jabatan")
            {
                kriteria = "jb.Nama";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);

            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewPegawai.Rows.Clear();

                for (int i = 0; i < daftar.JumlahPegawai; i++)
                {
                    string kode = daftar.ListPegawai[i].KodePegawai;
                    string nama = daftar.ListPegawai[i].Nama;
                    string tgl = daftar.ListPegawai[i].TanggalLahir;
                    string alamat = daftar.ListPegawai[i].Alamat;
                    string gaji = daftar.ListPegawai[i].Gaji;
                    string user = daftar.ListPegawai[i].Username;
                    string pass = daftar.ListPegawai[i].Password;

                    string namaJ = daftar.ListPegawai[i].JabatanPegawai.NamaJabatan;
                    dataGridViewPegawai.Rows.Add(kode, nama, tgl, alamat, gaji, user, pass, namaJ);
                }
            }
            else
            {
                MessageBox.Show("Gagal mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPegawai frm = new FormTambahPegawai();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPegawai frm = new FormUbahPegawai();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPegawai frm = new FormHapusPegawai();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
