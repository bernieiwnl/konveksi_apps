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
    public partial class FormHapusPekerjaan : Form
    {
        DaftarPekerjaan daftar;
        string hasil;

        public FormHapusPekerjaan()
        {
            InitializeComponent();
        }

        private void idPekerjaan_TextChanged(object sender, EventArgs e)
        {
            if (idPekerjaan.Text.Length != 0)
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
                        keterangan.Text = daftar.ListPekerjaan[0].Keterangan;

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

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            idPekerjaan.Text = "";
            idPegawai.SelectedIndex = -1;
            keterangan.Text = "";
            idKegiatan.SelectedIndex = -1;
        }

        private void FormHapusPekerjaan_Load(object sender, EventArgs e)
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
                MessageBox.Show("PEgawai gagal ditampilkan di comboBox. eror= " + hasil);
            }

            idKegiatan.Enabled = false;
            idPegawai.Enabled = false;
            keterangan.Enabled = false;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPekerjaan frm = (FormDaftarPekerjaan)this.Owner;
            frm.FormDaftarPekerjaan_Load(sender, e);
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data kategori akan terhapus. Apakah anda yakin ? ", " KONFIRMASI", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                string pegawai = idPegawai.Text;
                string kegiatan = idKegiatan.Text;


                string idpek = idPekerjaan.Text;

                string idpeg = pegawai.Split('-').First();
                string namapeg = pegawai.Split('-').Last();

                string idkeg = kegiatan.Split('-').First();
                string namakeg = kegiatan.Split('-').Last();

                kegiatan keg = new kegiatan(idkeg, namakeg);

                pegawai peg = new pegawai(idpeg, namapeg, default, "", "", "", "", null);


            
                string ket = keterangan.Text;

                pekerjaan pek = new pekerjaan(idpek, keg, peg, default, ket, "", 0 ,0 ,null);

                string hasilTambah = daftar.HapusData(pek);

                if (hasilTambah == "sukses")
                {
                    MessageBox.Show("Data Pekerjaan telah dihapus", "Info");
                }
                else
                {
                    MessageBox.Show("Data barang gagal dihapus. Error: " + hasilTambah, "Kesalahan");
                }

            }
        }
    }
}
