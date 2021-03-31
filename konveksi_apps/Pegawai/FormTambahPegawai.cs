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
    public partial class FormTambahPegawai : Form
    {
        public FormTambahPegawai()
        {
            InitializeComponent();
        }

        private void FormTambahPegawai_Load(object sender, EventArgs e)
        {
            DaftarPegawai daftar = new DaftarPegawai();
            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                textBoxKode.Text = daftar.KodeTerbaru;
                textBoxKode.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Eror: " + hasil);
            }

            DaftarJabatan dafJabat = new DaftarJabatan();
            hasil = dafJabat.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxJabatan.Items.Clear();

                for (int i = 0; i < dafJabat.JumlahJabatan; i++)
                {
                    comboBoxJabatan.Items.Add(dafJabat.ListJabatan[i].IdJabatan + " - " + dafJabat.ListJabatan[i].NamaJabatan);
                }
            }
            else
            {
                MessageBox.Show("Id Jabatan gagal ditampilkan di comboBox. Pesan Kesalahan = " + hasil);
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxPass.Text == textBoxUlPass.Text)
            {
                string idJabatan = comboBoxJabatan.Text.Substring(0, 2);
                string namaJabatan = comboBoxJabatan.Text.Substring(5, comboBoxJabatan.Text.Length - 5);

                jabatan jabat = new jabatan(idJabatan, namaJabatan);

                pegawai pgw = new pegawai(textBoxKode.Text, textBoxNama.Text, dateTimePickerTglLhr.Value, textBoxAlamat.Text,
                    textBoxGaji.Text, textBoxUser.Text, textBoxPass.Text, jabat);

                DaftarPegawai daftar = new DaftarPegawai();
                string hasilTambah = daftar.TambahData(pgw);

                if (hasilTambah == "sukses")
                {
                    MessageBox.Show("Data pegawai telah tersimpan", "Info");
                    daftar.GenerateKode();
                    textBoxKode.Text = daftar.KodeTerbaru;
                    buttonKosongi_Click(buttonKosongi, e);
                }
                else
                {
                    MessageBox.Show("Data pegawai gagal tersimpan. Pesan Kesalahan : " + hasilTambah, "Kesalahan");
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
            dateTimePickerTglLhr.Text = "";
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
