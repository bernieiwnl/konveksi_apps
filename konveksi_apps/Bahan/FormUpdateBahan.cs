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
    public partial class FormUpdateBahan : Form
    {
        public FormUpdateBahan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarBahan frm = (FormDaftarBahan)this.Owner;
            frm.FormDaftarBahan_Load(sender, e);
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxNama.Text = "";
            textBoxStok.Text = "";
            textBoxHargaBeli.Text = "";
            textBoxId.Focus();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            string jenisBahan = comboBoxJenisBahan.Text;
            string warna = comboBoxWarna.Text;
            string satuan = comboBoxSatuan.Text;

            string[] splitStringJenisBahan = jenisBahan.Split('-');
            string[] splitStringWarna = warna.Split('-');
            string[] splitStringSatuan = satuan.Split('-');

            warna w = new warna(int.Parse(splitStringWarna[0].Trim()), splitStringWarna[1].Trim());

            jenisBahan jb = new jenisBahan(splitStringJenisBahan[0].Trim(), splitStringJenisBahan[1].Trim());

            satuan s = new satuan(splitStringSatuan[0].Trim(), splitStringSatuan[1].Trim());

            bahan bhn = new bahan(textBoxId.Text, textBoxNama.Text, int.Parse(textBoxStok.Text), int.Parse(textBoxHargaBeli.Text), w , jb, s, int.Parse(textBoxMinimal.Text));
            DaftarBahan daftar = new DaftarBahan();
            string hasilUbah = daftar.UbahData(bhn);

            if (hasilUbah == "sukses")
            {
                MessageBox.Show("Data bahan telah diubah", "Info");

                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data bahan gagal diubah. Eror : " + hasilUbah, "Kesalahan");
            }
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxId.Text.Length == textBoxId.MaxLength)
            {
                DaftarBahan daftar = new DaftarBahan();
                string hasil = daftar.CariData("bahan.id", textBoxId.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahBahan > 0)
                    {
                        textBoxNama.Text = daftar.ListBahan[0].NamaBahan;
                        textBoxStok.Text = daftar.ListBahan[0].Stok.ToString();
                        textBoxMinimal.Text = daftar.ListBahan[0].Minimal.ToString();
                        textBoxHargaBeli.Text = daftar.ListBahan[0].HargaBeli.ToString();
                        comboBoxWarna.SelectedItem = daftar.ListBahan[0].Warna.Id + "-" + daftar.ListBahan[0].Warna.Nama_warna;
                        comboBoxJenisBahan.SelectedItem = daftar.ListBahan[0].Jenis_bahan.Id + "-" + daftar.ListBahan[0].Jenis_bahan.Nama_bahan;
                        comboBoxSatuan.SelectedItem = daftar.ListBahan[0].Satuan.Id + "-" + daftar.ListBahan[0].Satuan.NamaSatuan;
                    }
                    else
                    {
                        MessageBox.Show("Kode bahan tidak ditemukan. Proses hapus data tidak bisa dilakukan.");
                        textBoxId.Text = "";
                        textBoxNama.Text = "";
                        textBoxStok.Text = "";
                        textBoxHargaBeli.Text = "";
                        textBoxId.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankkan. Eror: " + hasil);
                }
            }
        }

        private void FormUpdateBahan_Load(object sender, EventArgs e)
        {
            textBoxId.MaxLength = 5;

            DaftarJenisBahan dafjenis = new DaftarJenisBahan();
            string hasil = dafjenis.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxJenisBahan.Items.Clear();

                for (int i = 0; i < dafjenis.JumlahJenisBahan; i++)
                {
                    comboBoxJenisBahan.Items.Add(dafjenis.ListJenisBahan[i].Id + "-" + dafjenis.ListJenisBahan[i].Nama_bahan);
                }
            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di comboBox. eror= " + hasil);
            }

            DaftarWarna dafwar = new DaftarWarna();
            hasil = dafwar.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxWarna.Items.Clear();

                for (int i = 0; i < dafwar.JumlahWarna; i++)
                {
                    comboBoxWarna.Items.Add(dafwar.Listwarna[i].Id + "-" + dafwar.Listwarna[i].Nama_warna);
                }
            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di comboBox. eror= " + hasil);
            }

            DaftarSatuan daftarSatuan = new DaftarSatuan();
            hasil = daftarSatuan.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxSatuan.Items.Clear();

                for (int i = 0; i < daftarSatuan.JumlahSatuan; i++)
                {
                    comboBoxSatuan.Items.Add(daftarSatuan.Satuans[i].Id + "-" + daftarSatuan.Satuans[i].NamaSatuan);
                }
            }
            else
            {
                MessageBox.Show("Satuan gagal ditampilkan di comboBox. eror= " + hasil);
            }
        }
    }
}
