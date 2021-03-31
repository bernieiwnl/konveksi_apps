using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using konveksi_apps.Form_Utama;
using konveksi_apps.Notifikasi;
using KonveksiClass;
namespace konveksi_apps.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
            
            textBoxServer.Text = "localhost";
            textBoxDb.Text = "mydb";

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxUser.Text != "")
            {
                Koneksi k = new Koneksi(textBoxServer.Text, textBoxDb.Text, textBoxUser.Text, textBoxPwd.Text);
                string hasilConnect = k.Connect();
                if(hasilConnect == "sukses")
                {
                    MessageBox.Show("Selamat Datang Di Sistem Penjualan Pembelian UD. Konveksi Dan Sablon Indra ", "info");
                    FormUtama frm = (FormUtama)this.Owner;
                    DaftarPegawai daftar = new DaftarPegawai();
                    string hasil = daftar.CariData("username", textBoxUser.Text);
                    if(hasil=="sukses")
                    {
                        frm.Enabled = true;
                        frm.labelKode.Text = daftar.ListPegawai[0].KodePegawai;
                        frm.labelNamaPegawai.Text = daftar.ListPegawai[0].Nama;
                        frm.labelNamaJabatan.Text = daftar.ListPegawai[0].JabatanPegawai.NamaJabatan;
                        PengaturanHakAksesMenu(daftar.ListPegawai[0].JabatanPegawai.NamaJabatan);
                        FormNotifikasi fnt = new FormNotifikasi();
                        fnt.Show();
                        this.Close();
                    }
                    

                }
                else
                {
                    MessageBox.Show("Username dan Password salah / tidak ada akun yang sesuai");
                }

            }
            else
            {
                MessageBox.Show("Username tidak boleh dikosongi", "kesalahan");
            }
        }

        private void PengaturanHakAksesMenu(string jbt)
        {
            FormUtama form = (FormUtama)this.Owner;
            FormNotifikasi fnt = new FormNotifikasi();
            
            if (jbt=="Kasir")
            {
                form.buttonTransaksi.Visible = true;
                form.buttonGaji.Visible = false;
                form.buttonMaster.Visible = false;
                form.buttonPembelian.Visible = true;
                form.buttonPenjualan.Visible = true;
                form.buttonLaporanMasterData.Visible = false;
                form.buttonLaporanTransaksi.Visible = false;
                fnt.Show();
            }
            else if(jbt=="Admin")
            {
                form.buttonMaster.Visible = true;
                form.buttonTransaksi.Visible = false;
                form.buttonLaporanMasterData.Visible = false;
                form.buttonLaporanTransaksi.Visible = false;
                fnt.Show();
            }
            else if (jbt=="Pemilik")
            {
                form.buttonMaster.Visible = true;
                form.buttonTransaksi.Visible = true;
                form.buttonLaporanTransaksi.Visible = true;
                form.buttonLaporanMasterData.Visible = true;
                fnt.Show();
            }
            else if (jbt == "Karyawan")
            {
                form.buttonTransaksi.Visible = true;
                form.buttonGaji.Visible = true;
                form.buttonMaster.Visible = false;
                form.buttonPembelian.Visible = false;
                form.buttonPenjualan.Visible = false;
                form.buttonLaporanMasterData.Visible = false;
                form.buttonLaporanTransaksi.Visible = false;
                fnt.Show();
            }
          

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void textBoxServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
