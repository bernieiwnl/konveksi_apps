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
    public partial class FormTambahBarang : Form
    {
        barang brg;
        DaftarBarang daftar;
        public FormTambahBarang()
        {
            InitializeComponent();
        }

        private void textBoxKodeBrg_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
            buttonCetakBarcode.Enabled = false;

            daftar = new DaftarBarang();

            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                textBoxKodeBrg.Text = daftar.KodeTerbaru;
                textBoxKodeBrg.Enabled = true;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Eror = " + hasil);
            }

            DaftarKategori dafKat = new DaftarKategori();
            hasil = dafKat.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxKategori.Items.Clear();

                for (int i = 0; i < dafKat.JumlahKategoriBarang; i++)
                {
                    comboBoxKategori.Items.Add(dafKat.DaftarKategoriBarang[i].KodeKategori + " - " + dafKat.DaftarKategoriBarang[i].NamaKategori);
                }
            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di comboBox. eror= " + hasil);
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

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            int harga = int.Parse(textBoxHarga.Text);
            int stok = int.Parse(textBoxStok.Text);
            int minimal = int.Parse(textBoxMinimal.Text);

            string satuan = comboBoxSatuan.Text;

            string kodeKategori = comboBoxKategori.Text.Substring(0, 2);
            string namaKategori = comboBoxKategori.Text.Substring(5, comboBoxKategori.Text.Length - 5);

            string[] splitStringSatuan = satuan.Split('-');


            kategori katBarang = new kategori(kodeKategori, namaKategori);
            satuan satBarang = new satuan(splitStringSatuan[0].Trim(), splitStringSatuan[1].Trim());

            brg = new barang(textBoxKodeBrg.Text, textBoxNamaBrg.Text, harga, stok, katBarang, satBarang, minimal);
            string hasilTambah = daftar.TambahData(brg);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data barang telah tersimpan", "Info");
                daftar.GenerateKode();
                textBoxKodeBrg.Text = daftar.KodeTerbaru;
                buttonKosongi_Click(buttonKosongi, e);
                buttonCetakBarcode.Enabled = true;
            }
            else
            {
                MessageBox.Show("Data barang gagal tersimpan. Error: " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNamaBrg.Text = "";
            textBoxHarga.Text = "";
            textBoxStok.Text = "";
            comboBoxKategori.SelectedIndex = -1;
            textBoxNamaBrg.Focus();
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
