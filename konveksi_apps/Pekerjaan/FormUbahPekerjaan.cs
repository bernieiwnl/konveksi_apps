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

namespace konveksi_apps.Pekerjaan
{
    public partial class FormUbahPekerjaan : Form
    {
        DaftarPekerjaan daftar;
        string hasil;
        public FormUbahPekerjaan()
        {
            InitializeComponent();
        }

        private void FormUbahPekerjaan_Load(object sender, EventArgs e)
        {
            DaftarKegiatan dafKat = new DaftarKegiatan();
            hasil = dafKat.BacaSemuaData();
            if (hasil == "sukses")
            {
                idKegiatan.Items.Clear();

                for (int i = 0; i < dafKat.JumlahJabatan; i++)
                {
                    idKegiatan.Items.Add(dafKat.ListKegiatan[i].IdKegiatan + "-" + dafKat.ListKegiatan[i].NamaKegiatan);
                }
            }
            else
            {
                MessageBox.Show("kegiatan gagal ditampilkan di comboBox. eror= " + hasil);
            }

            DaftarPegawai dafpeg = new DaftarPegawai();
            hasil = dafpeg.BacaSemuaData();
            if (hasil == "sukses")
            {
                idPegawai.Items.Clear();

                for (int i = 0; i < dafpeg.JumlahPegawai; i++)
                {
                    idPegawai.Items.Add(dafpeg.ListPegawai[i].KodePegawai + "-" + dafpeg.ListPegawai[i].Nama);
                }
            }
            else
            {
                MessageBox.Show("PEgawai gagal ditampilkan di comboBox. eror= " + hasil);
            }

            DaftarBarang dafbar = new DaftarBarang();
            hasil = dafbar.BacaSemuaData();
            if (hasil == "sukses")
            {
                idBarang.Items.Clear();

                for (int i = 0; i < dafbar.JumlahBarang; i++)
                {
                    idBarang.Items.Add(dafbar.ListBarang[i].KodeBarang + "-" + dafbar.ListBarang[i].NamaBarang);
                }
            }
            else
            {
                MessageBox.Show("PEgawai gagal ditampilkan di comboBox. eror= " + hasil);
            }
        }

        private void idPekerjaan_TextChanged(object sender, EventArgs e)
        {
            if(idPekerjaan.Text.Length != 0)
            {
                daftar = new DaftarPekerjaan();
                string hasil = daftar.CariData("idPengerjaan", idPekerjaan.Text);
                if (hasil == "sukses")
                {
                    if (daftar.JumlahPekerjaan > 0)
                    {
                        kegiatan kegiatan = daftar.ListPekerjaan[0].Kegiatan;
                        idKegiatan.SelectedItem = kegiatan.IdKegiatan + "-" + kegiatan.NamaKegiatan;
                        pegawai pegawai = daftar.ListPekerjaan[0].Pegawai;
                        idPegawai.SelectedItem = pegawai.KodePegawai + "-" + pegawai.Nama;
                        status.Text = daftar.ListPekerjaan[0].Status;
                        keterangan.Text = daftar.ListPekerjaan[0].Keterangan;
                        harga.Text = daftar.ListPekerjaan[0].Harga.ToString();
                        satuan.Text = daftar.ListPekerjaan[0].Satuan.ToString();
                        barang barang = daftar.ListPekerjaan[0].Barang;
                        idBarang.SelectedItem = barang.KodeBarang + "-" + barang.NamaBarang;
                       
                    }
                    else
                    {
                        MessageBox.Show("Kode barang tidak ditemukan. Proses Ubah Data tidak bisa dilakukan.");
                        idKegiatan.Text = "";
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
            string pegawai = idPegawai.Text;
            string kegiatan = idKegiatan.Text;


            string idpek = idPekerjaan.Text;

            string barang = idBarang.Text;

            string idpeg = pegawai.Split('-').First();
            string namapeg = pegawai.Split('-').Last();

            string idkeg = kegiatan.Split('-').First();
            string namakeg = kegiatan.Split('-').Last();

            string idBar = barang.Split('-').First();
            string namaBar = barang.Split('-').Last();

            kegiatan keg = new kegiatan(idkeg, namakeg);

            pegawai peg = new pegawai(idpeg, namapeg, default, "", "", "", "", null);

            barang bar = new barang(idBar, namaBar, 0, 0, null, null, 0);
               

            string stat = status.Text;
            string ket = keterangan.Text;
            string har = harga.Text;
            string sat = satuan.Text;

            pekerjaan pek = new pekerjaan(idpek, keg, peg, default, ket, stat, int.Parse(har), int.Parse(sat), bar);

            string hasilTambah = daftar.UbahData(pek);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data Pekerjaan telah tersimpan", "Info");
            }
            else
            {
                MessageBox.Show("Data barang gagal tersimpan. Error: " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            idPekerjaan.Text = "";
            idPegawai.SelectedIndex = -1;
            keterangan.Text = "";
            status.SelectedIndex = -1;
            idKegiatan.SelectedIndex = -1;

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPekerjaan frm = (FormDaftarPekerjaan)this.Owner;
            frm.FormDaftarPekerjaan_Load(sender, e);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
