using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace KonveksiClass
{
    public class pelanggan
    {
        private string kodePelanggan;
        private string namaPelanggan;
        private string alamat;
        private string telepon;

        public string KodePelanggan
        {
            get { return kodePelanggan; }
            set { kodePelanggan = value; }
        }

        public string NamaPelanggan
        {
            get { return namaPelanggan; }
            set { namaPelanggan = value; }
        }

        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        public string Telepon
        {
            get { return telepon; }
            set { telepon = value; }
        }

        public pelanggan()
        {
            kodePelanggan = "";
            namaPelanggan = "";
            alamat = "";
            telepon = "";
        }

        public pelanggan(string kode, string nama, string almt, string tlp)
        {
            kodePelanggan = kode;
            namaPelanggan = nama;
            alamat = almt;
            telepon = tlp;
        }
    }
}
