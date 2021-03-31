using KonveksiClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace konveksi_apps.Pekerjaan
{


    public partial class FormTambahPekerjaan : Form
    {
        DaftarPekerjaan daftar;


        public FormTambahPekerjaan()
        {
            InitializeComponent();
        }

        private void FormTambahPekerjaan_Load(object sender, EventArgs e)
        {
            string hasil = "";

            daftar = new DaftarPekerjaan();
            hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                idPekerjaan.Text = daftar.KodeTerbaru;
                idPekerjaan.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Eror = " + hasil);
            }

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
                MessageBox.Show("egiatan gagal ditampilkan di comboBox. eror= " + hasil);
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
                MessageBox.Show("Pegawai gagal ditampilkan di comboBox. eror= " + hasil);
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
                MessageBox.Show("Barang gagal ditampilkan di comboBox. eror= " + hasil);
            }

        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            idPegawai.SelectedIndex = -1;
            keterangan.Text = "";
            status.SelectedIndex = -1;
            idKegiatan.SelectedIndex = -1;
      
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            string pegawai = idPegawai.Text;
            string kegiatan = idKegiatan.Text;
            string barang = idBarang.Text;

            string idpek = idPekerjaan.Text;

            string idpeg = pegawai.Split('-').First();
            string namapeg = pegawai.Split('-').Last();

            string idkeg = kegiatan.Split('-').First();
            string namakeg = kegiatan.Split('-').Last();

            string idBar = barang.Split('-').First();
            string namaBar = barang.Split('-').Last();

            kegiatan keg = new kegiatan(idkeg, namakeg);

            pegawai peg = new pegawai(idpeg, namapeg, default, "", "", "", "", null);

            barang bar = new barang(idBar, namaBar, 0, 0, null, null, 0);


            string kete = keterangan.Text;
            string stat = status.Text;
            string har = harga.Text;
            string sat = satuan.Text;

            pekerjaan pek = new pekerjaan(idpek, keg, peg, default, kete, stat, int.Parse(har), int.Parse(sat), bar);

            string hasilTambah = daftar.TambahData(pek);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data Pekerjaan telah tersimpan", "Info");
                daftar.GenerateKode();
                idPekerjaan.Text = daftar.KodeTerbaru;
                buttonKosongi_Click(buttonKosongi, e);
            }
            else
            {
                MessageBox.Show("Data barang gagal tersimpan. Error: " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPekerjaan frm = (FormDaftarPekerjaan)this.Owner;
            frm.FormDaftarPekerjaan_Load(sender, e);
            this.Close();
        }

        private void idPekerjaan_TextChanged(object sender, EventArgs e)
        {

        }

        private void idBarang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
