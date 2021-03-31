using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class barang
    {
        private string kodeBarang;
        private string namaBarang;
        private int hargaJual;
        private int stok;
        private kategori kategoriBarang;
        private satuan satuan;
        private int minimal;


        public string KodeBarang
        {
            get { return kodeBarang; }
            set { kodeBarang = value; }
        }

        public string NamaBarang
        {
            get { return namaBarang; }
            set { namaBarang = value; }
        }

        public int HargaJual
        {
            get { return hargaJual; }
            set { hargaJual = value; }
        }

        public int Stok
        {
            get { return stok; }
            set { stok = value; }
        }

        public string KodeKategoriBarang
        {
            get { return kategoriBarang.KodeKategori; }
            set { KodeKategoriBarang = value; }
        }

        public string NamaKategoriBarang
        {
            get { return kategoriBarang.NamaKategori; }
            set { NamaKategoriBarang = value; }
        }

        public kategori KategoriBarang
        {
            get { return kategoriBarang; }
            set { kategoriBarang = value; }
        }

        public satuan Satuan { get => satuan; set => satuan = value; }
        public int Minimal { get => minimal; set => minimal = value; }

        public barang()
        {
            kodeBarang = "";
            namaBarang = "";
            hargaJual = 0;
            stok = 0;
            kategoriBarang = new kategori();
            satuan = new satuan();
            minimal = 0;
        }

        public barang(string kode, string nama, int harga, int stokBrg, kategori kat, satuan sat, int min)
        {
            kodeBarang = kode;
            namaBarang = nama;
            hargaJual = harga;
            stok = stokBrg;
            kategoriBarang = kat;
            satuan = sat;
            minimal = min;
        }
    }
}
