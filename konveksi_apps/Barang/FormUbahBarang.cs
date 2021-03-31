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
    public partial class FormUbahBarang : Form
    {
        barang brg;
        DaftarBarang daftar;
        public FormUbahBarang()
        {
            InitializeComponent();
        }

        private void FormUbahBarang_Load(object sender, EventArgs e)
        {
            buttonCetakBarcode.Enabled = false;

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
                MessageBox.Show("Kategori gagal ditampilkan di comboBox. Eror: " + hasil);
            }

            DaftarSatuan dafsat = new DaftarSatuan();
            hasil = dafsat.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxSatuan.Items.Clear();

                for (int i = 0; i < dafsat.JumlahSatuan; i++)
                {
                    comboBoxKategori.Items.Add(dafsat.Satuans[i].Id + " - " + dafsat.Satuans[i].NamaSatuan);
                }
            }
            else
            {
                MessageBox.Show("Satuan gagal ditampilkan di comboBox. eror= " + hasil);
            }
        }

        private void textBoxKodeBrg_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodeBrg.Text.Length == textBoxKodeBrg.MaxLength)
            {
                daftar = new DaftarBarang();
                string hasil = daftar.CariData("KodeBarang", textBoxKodeBrg.Text);
                if (hasil == "sukses")
                {
                    if (daftar.JumlahBarang > 0)
                    {
                        textBoxNamaBrg.Text = daftar.ListBarang[0].NamaBarang;
                        textBoxHarga.Text = daftar.ListBarang[0].HargaJual.ToString();
                        textBoxStok.Text = daftar.ListBarang[0].Stok.ToString();
                        kategori katBarang = daftar.ListBarang[0].KategoriBarang;
                        satuan satbarang = daftar.ListBarang[0].Satuan;
                        comboBoxSatuan.SelectedItem = satbarang.Id + " - " + satbarang.NamaSatuan;
                        comboBoxKategori.SelectedItem = katBarang.KodeKategori + " - " + katBarang.NamaKategori;
                        textBoxNamaBrg.Focus();
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

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            int harga = int.Parse(textBoxHarga.Text);
            int stok = int.Parse(textBoxStok.Text);
            string kodeKategori = comboBoxKategori.Text.Substring(0, 2);
            string namaKategori = comboBoxKategori.Text.Substring(5, comboBoxKategori.Text.Length - 5);

            int minimal = int.Parse(textBoxMinimal.Text);

            string satuan = comboBoxSatuan.Text;

            string[] splitStringSatuan = satuan.Split('-');

            satuan satBarang = new satuan(splitStringSatuan[0].Trim(), splitStringSatuan[1].Trim());

            kategori katBarang = new kategori(kodeKategori, namaKategori);

            brg = new barang(textBoxKodeBrg.Text, textBoxNamaBrg.Text, harga, stok, katBarang, satBarang, minimal);

            daftar = new DaftarBarang();

            string hasilTambah = daftar.UbahData(brg);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data barang telah diubah", "Info");
                buttonCetakBarcode.Enabled = true;
                buttonKosongi_Click(buttonKosongi, e);
            }
            else
            {
                MessageBox.Show("Data barang gagal diubah. Pesan Kesalahan : " + hasilTambah, "Kesalahan");
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

        private void buttonCetakBarcode_Click(object sender, EventArgs e)
        {
            string hasilCetak = daftar.CetakBarcode(brg);
            if (hasilCetak == "sukses")
            {
                MessageBox.Show("Proses cetak barcode berhasil.");
            }
            else
            {
                MessageBox.Show("Proses cetak barcode gagal. Pesan kesalahan : " + hasilCetak);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarBarang frm = (FormDaftarBarang)this.Owner;
            frm.DaftarBarang_Load(sender, e);
            this.Close();
        }
    }
}
