using konveksi_apps.Bahan;
using konveksi_apps.Barang;
using konveksi_apps.Jabatan;
using konveksi_apps.Jenis_Bahan;
using konveksi_apps.Kategori;
using konveksi_apps.Kegiatan;
using konveksi_apps.Login;
using konveksi_apps.Nota_Pembelian;
using konveksi_apps.Nota_Penjualan;
using konveksi_apps.Notifikasi;
using konveksi_apps.Pegawai;
using konveksi_apps.Pekerjaan;
using konveksi_apps.Pelanggan;
using konveksi_apps.Satuan;
using konveksi_apps.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace konveksi_apps.Form_Utama
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void hide()
        {
            if(panelSubMenuMaster.Visible==true)
            {
                panelSubMenuMaster.Visible = false;
            }
            if(panelSubMenuTransaksi.Visible==true)
            {
                panelSubMenuTransaksi.Visible = false;
            }
        }
        private void showmenu(Panel submenu)
        {
            if(submenu.Visible==false)
            {
                hide();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }

        }

        private void customizeDesign()
        {
            panelSubMenuMaster.Visible = false;
            panelSubMenuTransaksi.Visible = false;
        }
        private void FormUtama_Load(object sender, EventArgs e)
        {
                   
            this.IsMdiContainer = true;
            this.Enabled = false;
            FormLogin login = new FormLogin();
            login.Owner = this;
            login.Show();

            if(labelNamaJabatan.Text == "Karyawan" || labelNamaJabatan.Text == "Kasir")
            {
                buttonNotifikasi.Visible = false;
            }

        }
                
        private void buttonMaster_Click(object sender, EventArgs e)
        {
            showmenu(panelSubMenuMaster);
        }

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            showmenu(panelSubMenuTransaksi);

        }

        private void buttonBarang_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarBarang());
            hide();
        }

        private void buttonKategori_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarKategori ());
            hide();
        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarSupplier());
            hide();
        }

        private void buttonPegawai_Click(object sender, EventArgs e)
        {

            openChildForm(new FormDaftarPegawai());
            hide();
        }

        private void buttonJabatan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarJabatan());
            hide();
        }

        private void buttonPelanggan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarPelanggan());
            hide();
        }

        private void buttonPembelian_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarNotaBeli());
            FormDaftarNotaBeli notaB = new FormDaftarNotaBeli();
            notaB.MdiParent = this;
            hide();
        }

        private void buttonPenjualan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarNotaJual());
            FormDaftarNotaJual notaJ = new FormDaftarNotaJual();
            notaJ.MdiParent = this;
            hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm !=null)
            {
                activeForm.Close();
                
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormUtama.Controls.Add(childForm);
            panelFormUtama.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonLaporanMasterData_Click(object sender, EventArgs e)
        {
            openChildForm(new FormLaporanMaster());
            hide();
        }

        private void buttonLaporanTransaksi_Click(object sender, EventArgs e)
        {
            openChildForm(new FormLaporanTransaksi());
            hide();
        }

        private void panelFormUtama_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonKegiatan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarKegiatan());
            hide();
        }

        private void buttonPekerjaan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarPekerjaan());
            hide();
        }

        private void buttonNotif_Click(object sender, EventArgs e)
        {
            FormNotifikasi fmt = new FormNotifikasi();
            fmt.Show();
        }

        private void buttonBahan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarBahan());
            hide();
        }

        private void buttonJenisBahan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarJenisBahan());
            hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDaftarSatuan());
            hide();
        }
    }
}