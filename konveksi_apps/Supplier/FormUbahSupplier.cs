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
    public partial class FormUbahSupplier : Form
    {
        public FormUbahSupplier()
        {
            InitializeComponent();
        }

        private void FormUbahSupplier_Load(object sender, EventArgs e)
        {
            textBoxKode.MaxLength = 1;
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
                        textBoxNama.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode Supplier tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
                        textBoxNama.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankkan. Pesan kesalahan = " + hasil);
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            supplier sp = new supplier(textBoxKode.Text, textBoxNama.Text, textBoxAlamat.Text,jenisSuplier.Text);
            DaftarSupplier sup = new DaftarSupplier();
            string hasilUbah = sup.UbahData(sp);

            if (hasilUbah == "sukses")
            {
                MessageBox.Show("Data supplier telah diubah", "Info");

                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data supplier gagal diubah. Pesan kesalahan : " + hasilUbah, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarSupplier frm = (FormDaftarSupplier)this.Owner;
            frm.FormDaftarSupplier_Load(sender, e);
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKode.Text = "";
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";

            textBoxKode.Focus();
        }
    }
}
