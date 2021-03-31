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
    public partial class FormTambahSupplier : Form
    {
        public FormTambahSupplier()
        {
            InitializeComponent();
        }

        private void FormTambahSupplier_Load(object sender, EventArgs e)
        {
            DaftarSupplier daftar = new DaftarSupplier();
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
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            supplier sp = new supplier(textBoxKode.Text, textBoxNama.Text, textBoxAlamat.Text, jenisSuplier.Text);

            DaftarSupplier sup = new DaftarSupplier();
            string hasilTambah = sup.TambahData(sp);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data supplier berhasil tersimpan", "Info");

                buttonKeluar_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data supplier gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKode.Text = "";
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";
            jenisSuplier.Text = "";
            textBoxKode.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarSupplier frm = (FormDaftarSupplier)this.Owner;
            frm.FormDaftarSupplier_Load(sender, e);
            this.Close();
        }

 
    }
}
