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
    public partial class FormTambahBahan : Form
    {
        public FormTambahBahan()
        {
            InitializeComponent();
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

            bahan bhn = new bahan(textBoxId.Text, textBoxNama.Text, int.Parse(textBoxStok.Text), int.Parse(textBoxHargaBeli.Text),w,jb, s,int.Parse(textBoxMinimal.Text));
            DaftarBahan daftar = new DaftarBahan();
            string hasilSimpan = daftar.TambahData(bhn);
            if (hasilSimpan == "sukses")
            {
                MessageBox.Show("Data bahan berhasil disimpan", "Info");

            }
            else
            {
                MessageBox.Show("Data bahan gagal tersimpan. eror : " + hasilSimpan, "Kesalahan");

            }
        }

        private void FormTambahBahan_Load(object sender, EventArgs e)
        {
            DaftarBahan daftar = new DaftarBahan();
            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                textBoxId.Text = daftar.KodeTerbaru;
                textBoxId.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Eror: " + hasil);
            }


            DaftarJenisBahan dafjenis = new DaftarJenisBahan();
            hasil = dafjenis.BacaSemuaData();
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

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxNama.Text = "";
            textBoxStok.Text = "";
            textBoxHargaBeli.Text = "";
            textBoxNama.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarBahan frm = (FormDaftarBahan)this.Owner;
            frm.FormDaftarBahan_Load(sender, e);
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
