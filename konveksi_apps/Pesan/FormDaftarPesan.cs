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

namespace konveksi_apps.Pesan
{
    public partial class FormDaftarPesan : Form
    {
        public FormDaftarPesan()
        {
            InitializeComponent();
        }

        private void FormDaftarPesan_Load(object sender, EventArgs e)
        {
            labelIdPenerima.Visible = false;

            DaftarPesan daftar = new DaftarPesan();

            string hasil = daftar.CariData("idTujuan", labelIdPenerima.Text);
            if (hasil == "sukses")
            {
                FormatDataGrid();

                dataGridViewPesan.Rows.Clear();

                for (int i = 0; i < daftar.JumlahPesan; i++)
                {
                    string id = daftar.Listpesan[i].IdPesan;
                    string namaBahan = daftar.Listpesan[i].IdPenerima.Nama;
                    string nama_warna = daftar.Listpesan[i].Keterangan;
                    dataGridViewPesan.Rows.Add(id, namaBahan, nama_warna);
                }
            }
            else
            {
                MessageBox.Show("Gagal menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewPesan.Columns.Clear();

            dataGridViewPesan.Columns.Add("idPesan", "Kode Pesan");
            dataGridViewPesan.Columns.Add("NamaTujuan", "Nama Pengirim");
            dataGridViewPesan.Columns.Add("Keterangan", "Pesan");
         

            dataGridViewPesan.Columns["idPesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPesan.Columns["NamaTujuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPesan.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPesan frm = new FormTambahPesan();
            frm.labelIdPengirim.Text = labelIdPenerima.Text;
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPesan frm = new FormHapusPesan();
            frm.Owner = this;
            frm.Show();
        }
    }
}
