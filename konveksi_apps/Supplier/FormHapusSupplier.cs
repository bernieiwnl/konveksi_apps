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
namespace konveksi_apps.Supplier
{
    public partial class FormHapusSupplier : Form
    {
        public FormHapusSupplier()
        {
            InitializeComponent();
        }

        private void FormHapusSupplier_Load(object sender, EventArgs e)
        {
            textBoxKode.MaxLength = 1;
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data supplier akan terhapus. Apakah anda yakin ? ", " KONFIRMASI", MessageBoxButtons.YesNo);
            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                supplier sp = new supplier(textBoxKode.Text, textBoxNama.Text, textBoxAlamat.Text, "");

                DaftarSupplier sup = new DaftarSupplier();
                string hasilTambah = sup.HapusData(sp);

                if (hasilTambah == "sukses")
                {
                    MessageBox.Show("Data supplier berhasil dihapus", "Info");

                    buttonKosongi_Click(buttonHapus, e);
                }
                else
                {
                    MessageBox.Show("Data supplier gagal dihapus. Pesan kesalahan : " + hasilTambah, "Kesalahan");
                }
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKode.Text = "";
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";

            textBoxKode.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarSupplier frm = (FormDaftarSupplier)this.Owner;
            frm.FormDaftarSupplier_Load(sender, e);
            this.Close();
        }

        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKode.Text.Length == textBoxKode.MaxLength)
            {
                DaftarSupplier daftar = new DaftarSupplier();
                string hasil = daftar.CariData("KodeSupplier", textBoxKode.Text);

                if (hasil == "sukses")
                {
                    if (daftar.JumlahSupplier > 0)
                    {
                        textBoxNama.Text = daftar.ListSupplier[0].NamaSupplier;
                        textBoxAlamat.Text = daftar.ListSupplier[0].AlamatSupplier;
                        textBoxNama.Enabled = false;
                        textBoxAlamat.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Kode supplier tidak ditemukan. Proses hapus data tidak bisa dilakukan.");
                        textBoxNama.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankkan. Pesan kesalahan = " + hasil);
                }
            }
        }
    }
}
