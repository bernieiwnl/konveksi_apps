using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace KonveksiClass
{
    public class supplier
    {
        private string kodeSupplier;
        private string namaSupplier;
        private string alamatSupplier;
        private string jenisSuplier;

        public string KodeSupplier
        {
            get { return kodeSupplier; }
            set { kodeSupplier = value; }
        }

        public string NamaSupplier
        {
            get { return namaSupplier; }
            set { namaSupplier = value; }
        }

        public string AlamatSupplier
        {
            get { return alamatSupplier; }
            set { alamatSupplier = value; }
        }

        public string JenisSuplier { get => jenisSuplier; set => jenisSuplier = value; }

        public supplier()
        {
            kodeSupplier = "";
            namaSupplier = "";
            alamatSupplier = "";
            jenisSuplier = "";
        }

        public supplier(string kode, string nama, string alamat, string jenis)
        {
            kodeSupplier = kode;
            namaSupplier = nama;
            alamatSupplier = alamat;
            jenisSuplier = jenis;
        }
    }
}
