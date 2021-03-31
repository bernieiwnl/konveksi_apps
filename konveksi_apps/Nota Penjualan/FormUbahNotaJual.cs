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
namespace konveksi_apps.Nota_Penjualan
{
    public partial class FormUbahNotaJual : Form
    {
        notaJual nota;
        DaftarNotaJual daftar;
        public FormUbahNotaJual()
        {
            InitializeComponent();
        }

        private void FormUbahNotaJual_Load(object sender, EventArgs e)
        {

        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            string nomor = textBoxKodeBrg.Text;
            string status = comboBoxKategori.SelectedItem.ToString();
            nota = new notaJual(nomor, status);
            daftar = new DaftarNotaJual();
            string hasilTambah = daftar.UbahStatusPesanan(nota);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Status Nota telah diubah", "Info");
               
            }
            else
            {
                MessageBox.Show("Status gagal diubah. Pesan Kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarNotaJual frm = (FormDaftarNotaJual)this.Owner;
            frm.FormDaftarNotaJual_Load(sender, e);
            this.Close();
        }
    }
}
