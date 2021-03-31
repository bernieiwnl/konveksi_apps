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
    public partial class FormHapusPegawai : Form
    {
        public FormHapusPegawai()
        {
            InitializeComponent();
        }

        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKode.Text.Length <= textBoxKode.MaxLength)
            {
                DaftarPegawai daftar = new DaftarPegawai();

                string hasil = daftar.CariData("KodePegawai", textBoxKode.Text);

                if (hasil == "sukses")
                {
                    if (textBoxKode.Text == "")
                    {
                        textBoxNama.Clear();
                        textBoxPass.Clear();
                        comboBoxJabatan.SelectedIndex = 0;
                        textBoxUser.Clear();
                        dateTimePickerTglLhr.Value = DateTime.Now;
                        textBoxGaji.Clear();
                        textBoxAlamat.Clear();
                    }
                    else if (daftar.JumlahPegawai > 0)
                    {
                        textBoxNama.Text = daftar.ListPegawai[0].Nama;
                        dateTimePickerTglLhr.Value = DateTime.Parse(daftar.ListPegawai[0].TanggalLahir);
                        textBoxAlamat.Text = daftar.ListPegawai[0].Alamat;
                        textBoxUser.Text = daftar.ListPegawai[0].Username;
                        textBoxPass.Text = daftar.ListPegawai[0].Password;
                        textBoxGaji.Text = daftar.ListPegawai[0].Gaji.ToString();
                        comboBoxJabatan.Text = daftar.ListPegawai[0].IdJabatanPegawai + " - " + daftar.ListPegawai[0].NamaJabatanPegawai;

                        textBoxNama.Enabled = false;
                        dateTimePickerTglLhr.Enabled = false;
                        textBoxAlamat.Enabled = false;
                        textBoxUser.Enabled = false;
                        textBoxPass.Enabled = false;
                        textBoxGaji.Enabled = false;
                        comboBoxJabatan.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Kode pegawai tidak ditemukan. Proses Ubah Data tidak bisa dilakukan.");
                        textBoxNama.Clear();
                        textBoxPass.Clear();
                        comboBoxJabatan.SelectedIndex = 0;
                        textBoxUser.Clear();
                        dateTimePickerTglLhr.Value = DateTime.Now;
                        textBoxGaji.Clear();
                        textBoxAlamat.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan Kesalahan: " + hasil);
                }
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data Pegawai akan terhapus. Apakah anda yakin ? ", "Konfirmasi", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                string kodeJab = comboBoxJabatan.Text.Substring(0, 2); //dimulai dari 0, diambilnya cuman 2
                string namaJab = comboBoxJabatan.Text.Substring(5, comboBoxJabatan.Text.Length - 5);

                jabatan j = new jabatan(kodeJab, namaJab);

                pegawai p = new pegawai(textBoxKode.Text, textBoxNama.Text, dateTimePickerTglLhr.Value, textBoxAlamat.Text, textBoxGaji.Text, textBoxUser.Text, textBoxPass.Text, j);

                DaftarPegawai daftar = new DaftarPegawai();

                string hasil = daftar.HapusData(p);

                if (hasil == "sukses")
                {
                    MessageBox.Show("Data telah terhapus", "Info");
                    buttonKosongi_Click(buttonHapus, e);
                }
                else
                {
                    MessageBox.Show("Data gagal dihapus. Pesan kesalahan= " + hasil, "Kesalahan");
                }
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKode.Clear();
            textBoxNama.Clear();
            textBoxPass.Clear();
            comboBoxJabatan.SelectedIndex = 0;
            textBoxUser.Clear();
            dateTimePickerTglLhr.Value = DateTime.Now;
            textBoxGaji.Clear();
            textBoxAlamat.Clear();
        }

        private void FormHapusPegawai_Load(object sender, EventArgs e)
        {
            textBoxKode.MaxLength = 1;

            DaftarJabatan daftar = new DaftarJabatan();

            string hasil = daftar.BacaSemuaData();

            if (hasil == "sukses")
            {
                comboBoxJabatan.Items.Clear();

                for (int i = 0; i < daftar.JumlahJabatan; i++)
                {
                    comboBoxJabatan.Items.Add(daftar.ListJabatan[i].IdJabatan + " - " + daftar.ListJabatan[i].NamaJabatan);
                }
            }
            else
            {
                MessageBox.Show("Jabatan gagal ditampilkan di comboBox. Pesan kesalahan  = " + hasil);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPegawai frm = (FormDaftarPegawai)this.Owner;
            frm.FormDaftarPegawau_Load(sender, e);
            this.Close();
        }
    }
}
