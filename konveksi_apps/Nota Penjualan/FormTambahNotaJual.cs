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
using KonveksiClass;
namespace konveksi_apps.Nota_Penjualan
{
    public partial class FormTambahNotaJual : Form
    {
        public FormTambahNotaJual()
        {
            InitializeComponent();
        }
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FormUtama"];
        DaftarNotaJual daftar;
        int subTotal = 0;
        private void FormTambahNotaJual_Load(object sender, EventArgs e)
        {

            daftar = new DaftarNotaJual();
            string hasil = daftar.GenerateNoNota();
            if (hasil == "sukses")
            {
                textBoxNoNota.Text = daftar.NoNotaBaru;
                textBoxNoNota.Enabled = false;
            }

            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Pesan kesalahan = " + hasil);
            }

            dateTimePickerNota.Value = DateTime.Now;
            dateTimePickerNota.Enabled = false;

            comboBoxNamaBarang.DropDownStyle = ComboBoxStyle.DropDownList;
            DaftarBarang brg = new DaftarBarang();

            hasil = brg.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxNamaBarang.Items.Clear();

                for (int i = 0; i < brg.JumlahBarang; i++)
                {
                    comboBoxNamaBarang.Items.Add(brg.ListBarang[i].NamaBarang);
                }

                comboBoxNamaBarang.SelectedIndex = 0;
            }

            else
            {
                MessageBox.Show("Data pelanggan gagal ditampilkan di comboBox. Pesan kesalahan = " + hasil);
            }

            comboBoxPelanggan.DropDownStyle = ComboBoxStyle.DropDownList;
            DaftarPelanggan plg = new DaftarPelanggan();

            hasil = plg.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxPelanggan.Items.Clear();

                for (int i = 0; i < plg.JumlahPelanggan; i++)
                {
                    comboBoxPelanggan.Items.Add(plg.ListPelanggan[i].KodePelanggan + " - " + plg.ListPelanggan[i].NamaPelanggan);
                }

                comboBoxPelanggan.SelectedIndex = 0;
            }

            else
            {
                MessageBox.Show("Data pelanggan gagal ditampilkan di comboBox. Pesan kesalahan = " + hasil);
            }

            labelKodePgw.Text = ((FormUtama)f).labelKode.Text;
            labelNamaPegawai.Text = ((FormUtama)f).labelNamaPegawai.Text;




            FormatDataGrid();

            textBoxKodeBrg.MaxLength = 5;
            textBoxKodeBrg.CharacterCasing = CharacterCasing.Upper;

        }

        private void FormatDataGrid()
        {
            dataGridViewNotaJual.Columns.Clear();

            dataGridViewNotaJual.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewNotaJual.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewNotaJual.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewNotaJual.Columns.Add("Jumlah", "Jumlah");
            dataGridViewNotaJual.Columns.Add("SubTotal", "Sub Total");

            dataGridViewNotaJual.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNotaJual.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNotaJual.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewNotaJual.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
            dataGridViewNotaJual.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewNotaJual.AllowUserToAddRows = false;
        }

        private void comboBoxPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kodePelanggan = comboBoxPelanggan.Text.Substring(0, 1);
            DaftarPelanggan daftar = new DaftarPelanggan();
            daftar.CariData("KodePelanggan", kodePelanggan);
            textBoxAlamat.Text = daftar.ListPelanggan[0].Alamat;
        }

        private int HitungGrandTotal()
        {
            int grandTotal = 0;

            for (int i = 0; i < dataGridViewNotaJual.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewNotaJual.Rows[i].Cells["SubTotal"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            int jumlah = int.Parse(textBoxJumlah.Text);
            DaftarBarang daftar = new DaftarBarang();
            string hasil = daftar.CariData("KodeBarang", textBoxKodeBrg.Text);

            if (hasil == "sukses")
            {   
                if(daftar.ListBarang[0].Minimal > jumlah)
                {
                    MessageBox.Show("Pembelian Barang Minimal " + daftar.ListBarang[0].Minimal + " " + daftar.ListBarang[0].Satuan.NamaSatuan); 
                }
                else
                {
                    subTotal = int.Parse(textBoxHargaBrg.Text) * int.Parse(textBoxJumlah.Text);
                    dataGridViewNotaJual.Rows.Add(textBoxKodeBrg.Text, comboBoxNamaBarang.SelectedItem.ToString(), textBoxHargaBrg.Text, textBoxJumlah.Text, subTotal);

                    labelTotalHarga.Text = HitungGrandTotal().ToString();

                    textBoxKodeBrg.Text = "";
                    comboBoxNamaBarang.SelectedIndex = 0;
                    textBoxHargaBrg.Text = "";
                    textBoxJumlah.Text = "";
                    textBoxKodeBrg.Focus();
                }
            }
            else
            {
                MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasil);
            }
            
        }

        private void buttonKurangi_Click(object sender, EventArgs e)
        {
            int pengurangan = 0;
            foreach (DataGridViewRow row in dataGridViewNotaJual.SelectedRows)
            {
                string valueTabel = row.Cells[4].Value.ToString();
                int valueSubTotal = int.Parse(valueTabel);
                int jumlah = int.Parse(labelTotalHarga.Text);
                pengurangan = jumlah - valueSubTotal;

                dataGridViewNotaJual.Rows.RemoveAt(row.Index);
            }
            labelTotalHarga.Text = pengurangan.ToString();
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            daftar.CetakNota("NoNota", textBoxNoNota.Text, "nota_jual.txt");

            MessageBox.Show("Nota jual telah tercetak");
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            string kodePelanggan = comboBoxPelanggan.Text.Substring(0, 1);
            string namaPelanggan = comboBoxPelanggan.Text.Substring(4, comboBoxPelanggan.Text.Length - 4);
            string status = comboBoxstts.SelectedItem.ToString();
            pelanggan plg = new pelanggan();
            plg.KodePelanggan = kodePelanggan;
            plg.NamaPelanggan = namaPelanggan;

            pegawai pgw = new pegawai();
            pgw.KodePegawai = labelKodePgw.Text;
            pgw.Nama = labelNamaPegawai.Text;

            List<notaJualDetail> listNotaDetil = new List<notaJualDetail>();

            for (int i = 0; i < dataGridViewNotaJual.Rows.Count; i++)
            {
                barang brg = new barang();
                brg.KodeBarang = dataGridViewNotaJual.Rows[i].Cells["KodeBarang"].Value.ToString();
                brg.NamaBarang = dataGridViewNotaJual.Rows[i].Cells["NamaBarang"].Value.ToString();
                int harga = int.Parse(dataGridViewNotaJual.Rows[i].Cells["HargaJual"].Value.ToString());
                int jumlah = int.Parse(dataGridViewNotaJual.Rows[i].Cells["Jumlah"].Value.ToString());

                notaJualDetail notaDetil = new notaJualDetail(brg, harga, jumlah);
                listNotaDetil.Add(notaDetil);
            }

            notaJual nota = new notaJual(textBoxNoNota.Text, dateTimePickerNota.Value, dateTimePickerSelesai.Value, plg, pgw, status,listNotaDetil);

            daftar = new DaftarNotaJual();
            string hasilTambah = daftar.TambahData(nota);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data nota jual telah tersimpan", "Info");
                buttonCetak_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data nota jual gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            FormDaftarNotaJual frm = (FormDaftarNotaJual)this.Owner;
            frm.FormDaftarNotaJual_Load(sender, e);
            this.Close();
        }

        private void textBoxJumlah_TextChanged(object sender, EventArgs e)
        {
           
               
        }

        private void comboBoxNamaBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodBarang();

        }

        private void methodBarang()
        {

            DaftarBarang daftar = new DaftarBarang();
            string hasil = daftar.CariData("B.Nama", comboBoxNamaBarang.SelectedItem.ToString());

            if (hasil == "sukses")
            {
                if (daftar.JumlahBarang > 0)
                {
                    textBoxKodeBrg.Text = daftar.ListBarang[0].KodeBarang;
                    textBoxHargaBrg.Text = daftar.ListBarang[0].HargaJual.ToString();
                    textBoxJumlah.Focus();
                }
                else
                {
                    MessageBox.Show("Kode barang tidak ditemukan.");
                    textBoxKodeBrg.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasil);
            }

        }
    }
}
