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
    public partial class FormUbahPegawai : Form
    {
        public FormUbahPegawai()
        {
            InitializeComponent();
        }

        private void FormUbahPegawai_Load(object sender, EventArgs e)
        {
            textBoxKode.MaxLength = 2;

            DaftarJabatan daftarJabat = new DaftarJabatan();
            string hasil = daftarJabat.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxJabatan.Items.Clear();
                for (int i = 0; i < daftarJabat.JumlahJabatan; i++)
                {
                    comboBoxJabatan.Items.Add(daftarJabat.ListJabatan[i].IdJabatan +
                        " - " + daftarJabat.ListJabatan[i].NamaJabatan);
                }
            }
            else
            {
                MessageBox.Show("Jabatan gagal ditampilkan di comboBox. Pesan Kesalahan = " + hasil);
            }
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

                    }
                    else
                    {
                        MessageBox.Show("Kode pegawai tidak ditemukan. Proses Ubah Data tidak bisa dilakukan.");
                        textBoxNama.Clear();
                        textBoxPass.Clear();
                        textBoxUlPass.Clear();
                        comboBoxJabatan.SelectedIndex = 0;
                        textBoxUser.Clear();
                        dateTimePickerTglLhr.Value = DateTime.Now;
                        textBoxGaji.Clear();
                        textBoxAlamat.Clear();
                    }
                    textBoxKode.Enabled = false;
                    textBoxUser.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan Kesalahan: " + hasil);
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxPass.Text == textBoxUlPass.Text)
            {
                string kodeJab = comboBoxJabatan.Text.Substring(0, 2); //dimulai dari 0, diambilnya cuman 2
                string namaJab = comboBoxJabatan.Text.Substring(5, comboBoxJabatan.Text.Length - 5);
                jabatan jabat = new jabatan(kodeJab, namaJab);

                pegawai p = new pegawai(textBoxKode.Text, textBoxNama.Text, dateTimePickerTglLhr.Value, textBoxAlamat.Text, textBoxGaji.Text, textBoxUser.Text, textBoxPass.Text, jabat);
                DaftarPegawai daftar = new DaftarPegawai();

                string hasil = daftar.UbahData(p);

                if (hasil == "sukses")
                {
                    MessageBox.Show("Data telah diubah", "Info");
                    buttonKosongi_Click(buttonSimpan, e);
                }
                else
                {
                    MessageBox.Show("Data gagal diubah. Pesan kesalahan= " + hasil, "Kesalahan");
                }
            }
            else
            {
                MessageBox.Show("Password yang anda masukkan salah. Silahkan masukkan lagi yang benar");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNama.Text = "";
            dateTimePickerTglLhr.Value = DateTime.Now;
            textBoxAlamat.Text = "";
            textBoxGaji.Text = "";
            textBoxUser.Text = "";
            textBoxPass.Text = "";
            textBoxUlPass.Text = "";
            comboBoxJabatan.SelectedIndex = -1;
            textBoxNama.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPegawai frm = (FormDaftarPegawai)this.Owner;
            frm.FormDaftarPegawau_Load(sender, e);
            this.Close();
        }
    }
}
