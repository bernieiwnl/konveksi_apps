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
namespace konveksi_apps.Barang
{
    public partial class FormHapusBarang : Form
    {
        public FormHapusBarang()
        {
            InitializeComponent();
        }

        private void textBoxKodeBrg_TextChanged(object sender, EventArgs e)
        {
            
                if (textBoxKodeBrg.Text.Length == textBoxKodeBrg.MaxLength)
                {
                    DaftarBarang daftar = new DaftarBarang();
                    string hasil = daftar.CariData("KodeBarang", textBoxKodeBrg.Text);
                    if (hasil == "sukses")
                    {
                        if (daftar.JumlahBarang > 0)
                        {
                            textBoxNamaBrg.Text = daftar.ListBarang[0].NamaBarang;
                            textBoxHarga.Text = daftar.ListBarang[0].HargaJual.ToString();
                            textBoxStok.Text = daftar.ListBarang[0].Stok.ToString();
                    
                            kategori katBarang = daftar.ListBarang[0].KategoriBarang;
                            comboBoxKategori.SelectedItem = katBarang.KodeKategori + " - " + katBarang.NamaKategori;

                            textBoxNamaBrg.Enabled = false;
          
                            textBoxHarga.Enabled = false;
                            textBoxStok.Enabled = false;
                            comboBoxKategori.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Kode barang tidak ditemukan. Proses Ubah Data tidak bisa dilakukan.");
                            textBoxNamaBrg.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasil);
                    }
                }
            }

        

        private void FormHapusBarang_Load(object sender, EventArgs e)
        {
            textBoxKodeBrg.MaxLength = 5;

            DaftarKategori daftarKat = new DaftarKategori();
            string hasil = daftarKat.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxKategori.Items.Clear();
                for (int i = 0; i < daftarKat.JumlahKategoriBarang; i++)
                {
                    comboBoxKategori.Items.Add(daftarKat.DaftarKategoriBarang[i].KodeKategori +
                        " - " + daftarKat.DaftarKategoriBarang[i].NamaKategori);
                }
            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di comboBox. Pesan Kesalahan = " + hasil);
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data kategori akan terhapus. Apakah anda yakin ? ", " KONFIRMASI", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                int harga = int.Parse(textBoxHarga.Text);
                int stok = int.Parse(textBoxStok.Text);
                string kodeKategori = comboBoxKategori.Text.Substring(0, 2);
                string namaKategori = comboBoxKategori.Text.Substring(5, comboBoxKategori.Text.Length - 5);

                kategori katBarang = new kategori(kodeKategori, namaKategori);

                barang brg = new barang(textBoxKodeBrg.Text, textBoxNamaBrg.Text, harga, stok, katBarang, null, 0);

                DaftarBarang daftar = new DaftarBarang();

                string hasilTambah = daftar.HapusData(brg);

                if (hasilTambah == "sukses")
                {
                    MessageBox.Show("Data barang telah dihapus", "Info");

                    buttonKosongi_Click(buttonKosongi, e);
                }
                else
                {
                    MessageBox.Show("Data barang gagal dihapus. Pesan Kesalahan : " + hasilTambah, "Kesalahan");
                }

            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodeBrg.Text = "";
            textBoxNamaBrg.Text = "";
            textBoxHarga.Text = "";
            textBoxStok.Text = "";
            comboBoxKategori.SelectedIndex = -1;
            textBoxKodeBrg.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarBarang frm = (FormDaftarBarang)this.Owner;
            frm.DaftarBarang_Load(sender, e);
            this.Close();
        }
    }
}
