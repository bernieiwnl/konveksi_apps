using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class notaJualDetail
    {
        private barang barangNota;
        private int hargaJual;
        private int jumlahJual;

        public barang BarangNota
        {
            get { return barangNota; }
            set { barangNota = value; }
        }

        public int HargaJual
        {
            get { return hargaJual; }
            set { hargaJual = value; }
        }

        public int JumlahJual
        {
            get { return jumlahJual; }
            set { jumlahJual = value; }
        }


        public notaJualDetail()
        {
            barangNota = new barang();
            hargaJual = 0;
            jumlahJual = 0;
        }

        public notaJualDetail(barang brg, int hrg, int jml)
        {
            barangNota = brg;
            hargaJual = hrg;
            jumlahJual = jml;
        }
    }
}
