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
namespace konveksi_apps.Nota_Pembelian
{
    public partial class FormTambahNotaBeli : Form
    {
        public FormTambahNotaBeli()
        {
            InitializeComponent();
        }
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FormUtama"];
        DaftarNotaBeli daftar;
        int subTotal = 0;
        private void FormTambahNotaBeli_Load(object sender, EventArgs e)
        {
            daftar = new DaftarNotaBeli();
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
            comboBoxBahanBaku.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarJenisBahan bhn = new DaftarJenisBahan();

            hasil = bhn.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxBahanBaku.Items.Clear();
                for (int i = 0; i < bhn.ListJenisBahan.Count; i++)
                {
                    comboBoxBahanBaku.Items.Add(bhn.ListJenisBahan[i].Id + "-" + bhn.ListJenisBahan[i].Nama_bahan);
                }
            }

            else
            {
                MessageBox.Show("Data supplier gagal ditampilkan di comboBox. Pesan kesalahan = " + hasil);
            }


            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            DaftarSupplier sup = new DaftarSupplier();

            hasil = sup.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxSupplier.Items.Clear();

                for (int i = 0; i < sup.JumlahSupplier; i++)
                {
                    comboBoxSupplier.Items.Add(sup.ListSupplier[i].KodeSupplier + " - " + sup.ListSupplier[i].NamaSupplier);
                }
            }

            else
            {
                MessageBox.Show("Data supplier gagal ditampilkan di comboBox. Pesan kesalahan = " + hasil);
            }


            labelKodePgw.Text = ((FormUtama)f).labelKode.Text;
            labelNama.Text = ((FormUtama)f).labelNamaPegawai.Text;

            FormatDataGrid();

            textBoxKodeBrg.MaxLength = 5;
            textBoxKodeBrg.CharacterCasing = CharacterCasing.Upper;
           
        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewBarang.Columns.Add("HargaBeli", "Harga Beli");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("SubTotal", "Sub Total");

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["HargaBeli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewBarang.Columns["HargaBeli"].DefaultCellStyle.Format = "0,###";
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewBarang.AllowUserToAddRows = false;
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kodeSupplier = comboBoxSupplier.Text.Substring(0, 1);
            DaftarSupplier daftar = new DaftarSupplier();
            daftar.CariData("KodeSupplier", kodeSupplier);
            textBoxAlamat.Text = daftar.ListSupplier[0].AlamatSupplier;
        }



       
        private int HitungGrandTotal()
        {
            int grandTotal = 0;

            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewBarang.Rows[i].Cells["SubTotal"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            subTotal = int.Parse(textBoxHargaBrg.Text) * int.Parse(textBoxJumlah.Text);
            dataGridViewBarang.Rows.Add(textBoxKodeBrg.Text, comboBoxNamaBarang.SelectedItem.ToString(), textBoxHargaBrg.Text, textBoxJumlah.Text, subTotal);

            labelTotalHarga.Text = HitungGrandTotal().ToString();

            textBoxKodeBrg.Text = "";
            comboBoxNamaBarang.SelectedIndex = 0;
            textBoxHargaBrg.Text = "";
            textBoxJumlah.Text = "";
            textBoxKodeBrg.Focus();
        }

        private void buttonKurangi_Click(object sender, EventArgs e)
        {
            int pengurangan = 0;
            foreach (DataGridViewRow row in dataGridViewBarang.SelectedRows)
            {
                string valueTabel = row.Cells[4].Value.ToString();
                int valueSubTotal = int.Parse(valueTabel);
                int jumlah = int.Parse(labelTotalHarga.Text);
                pengurangan = jumlah - valueSubTotal;

                dataGridViewBarang.Rows.RemoveAt(row.Index);
            }
            labelTotalHarga.Text = pengurangan.ToString();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            string kodeSupplier = comboBoxSupplier.Text.Substring(0, 1);
            string namaSupplier = comboBoxSupplier.Text.Substring(4, comboBoxSupplier.Text.Length - 4);

            supplier sup = new supplier();
            sup.KodeSupplier = kodeSupplier;
            sup.NamaSupplier = namaSupplier;

            pegawai pgw = new pegawai();
            pgw.KodePegawai = labelKodePgw.Text;
            pgw.Nama = labelNama.Text;

            List<notaBeliDetail> listNotaDetil = new List<notaBeliDetail>();

            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                bahan bhn = new bahan();
                bhn.Id = dataGridViewBarang.Rows[i].Cells["KodeBarang"].Value.ToString();
                bhn.NamaBahan = dataGridViewBarang.Rows[i].Cells["NamaBarang"].Value.ToString();
                int harga = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaBeli"].Value.ToString());
                int jumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].Value.ToString());

                notaBeliDetail notaDetil = new notaBeliDetail(bhn, harga, jumlah);
                listNotaDetil.Add(notaDetil);
            }

            notaBeli nota = new notaBeli(textBoxNoNota.Text, dateTimePickerNota.Value, sup, pgw, listNotaDetil);

            DaftarNotaBeli daftar = new DaftarNotaBeli();
            string hasilTambah = daftar.TambahData(nota);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data nota beli telah tersimpan", "Info");
               
            }
            else
            {
                MessageBox.Show("Data nota beli gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            DaftarNotaBeli daftar = new DaftarNotaBeli();
            daftar.CetakNota("NoNota", textBoxNoNota.Text, "nota_beli.txt");

            MessageBox.Show("Nota beli telah tercetak");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            FormDaftarNotaBeli frm = (FormDaftarNotaBeli)this.Owner;
            frm.FormDaftarNotaBeli_Load(sender, e);
            this.Close();
        }

        private void comboBoxBahanBaku_SelectedIndexChanged(object sender, EventArgs e)
        {
            methodsupbahan();
            methodnamaBahan();
        }

        private void comboBoxBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBahan(); 
        }

        public void methodsupbahan()
        {
            DaftarSupplier dftrsup = new DaftarSupplier();
            string result = comboBoxBahanBaku.Text;
            string[] splitResult = result.Split('-');

            string hasil = dftrsup.CariData("jenisSuplier", splitResult[1].Trim());
            if (hasil == "sukses")
            {
                comboBoxSupplier.Items.Clear();

                for (int i = 0; i < dftrsup.JumlahSupplier; i++)
                {
                    comboBoxSupplier.Items.Add(dftrsup.ListSupplier[i].KodeSupplier + " - " + dftrsup.ListSupplier[i].NamaSupplier);
                }
            }

            else
            {
                MessageBox.Show("Data supplier gagal ditampilkan di comboBox. Pesan kesalahan = " + hasil);
            }
        }

        public void checkBahan()
        {
            DaftarBahan daftarBahan = new DaftarBahan();
            string result = comboBoxBahanBaku.Text;

            string[] splitResult = result.Split('-');

            string hasil = daftarBahan.CariData("jb.nama_bahan", splitResult[1].Trim());
            if (hasil == "sukses")
            {
                for (int i = 0; i < daftarBahan.JumlahBahan; i++)
                {
                    textBoxKodeBrg.Text = daftarBahan.ListBahan[i].Id;
                    textBoxHargaBrg.Text = daftarBahan.ListBahan[i].HargaBeli.ToString();
                }
            }

            else
            {
                MessageBox.Show("Data supplier gagal ditampilkan di comboBox. Pesan kesalahan = " + hasil);
            }
        }

        public void methodnamaBahan()
        {
            DaftarBahan daftarBahan = new DaftarBahan();
            string result = comboBoxBahanBaku.Text;

            string[] splitResult = result.Split('-');

            string hasil = daftarBahan.CariData("jb.nama_bahan", splitResult[1].Trim());
            if (hasil == "sukses")
            {
                comboBoxNamaBarang.Items.Clear();

                for (int i = 0; i < daftarBahan.JumlahBahan; i++)
                {
                    comboBoxNamaBarang.Items.Add(daftarBahan.ListBahan[i].Id + " - " + daftarBahan.ListBahan[i].NamaBahan + " - " + daftarBahan.ListBahan[i].Warna.Nama_warna);
                }
            }

            else
            {
                MessageBox.Show("Data supplier gagal ditampilkan di comboBox. Pesan kesalahan = " + hasil);
            }
        }
    }

}
