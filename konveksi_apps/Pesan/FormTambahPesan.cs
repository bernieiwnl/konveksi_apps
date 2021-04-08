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

namespace konveksi_apps.Pesan  
{
    public partial class FormTambahPesan : Form
    {
        private string id = "";
    
        public FormTambahPesan()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            string penerima = comboBoxPenerima.Text;
            string[] splitStringPenerima = penerima.Split('-');

            pegawai p1 = new pegawai(splitStringPenerima[0].Trim(), splitStringPenerima[1].Trim(), default, null,null,null,null,null);
            pegawai p2 = new pegawai(labelIdPengirim.Text, null, default, null, null, null, null, null);

            pesan psn = new pesan(id, p1, p2, richTextBoxKeterangan.Text);
            DaftarPesan daftar = new DaftarPesan();
            string hasilSimpan = daftar.TambahData(psn);

            if (hasilSimpan == "sukses")
            {
                MessageBox.Show("Data bahan berhasil disimpan", "Info");
            }
            else
            {
                MessageBox.Show("Data bahan gagal tersimpan. eror : " + hasilSimpan, "Kesalahan");
            }
        }

        private void FormTambahPesan_Load(object sender, EventArgs e)
        {
            labelIdPengirim.Visible = false;

            DaftarPesan pesan = new DaftarPesan();
            string hasil = pesan.GenerateKode();
            if (hasil == "sukses")
            {
                id = pesan.KodeTerbaru;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Eror: " + hasil);
            }
            

            DaftarPegawai penerima = new DaftarPegawai();
            hasil = penerima.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxPenerima.Items.Clear();

                for (int i = 0; i < penerima.JumlahPegawai; i++)
                {
                    comboBoxPenerima.Items.Add(penerima.ListPegawai[i].KodePegawai + " - " + penerima.ListPegawai[i].Nama);
                }
            }
            else
            {
                MessageBox.Show("Satuan gagal ditampilkan di comboBox. eror= " + hasil);
            }
        }
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
