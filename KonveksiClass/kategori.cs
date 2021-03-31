using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class kategori
    {
        private string kodeKategori;
        private string namaKategori;
        

        public string KodeKategori
        {
            get { return kodeKategori; }
            set { kodeKategori = value; }
        }

        public string NamaKategori
        {
            get { return namaKategori; }
            set { namaKategori = value; }
        }
       
        public kategori()
        {
            kodeKategori = "";
            namaKategori = "";
        }

        public kategori(string kode, string nama)
        {
            kodeKategori = kode;
            namaKategori = nama;
        }
    }
}
