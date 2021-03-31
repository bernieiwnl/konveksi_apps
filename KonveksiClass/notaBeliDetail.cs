using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class notaBeliDetail
    {
        private bahan bahanNota;
        private int hargaBeli;
        private int jumlahBeli;

        public bahan BahanNota
        {
            get { return bahanNota; }
            set { bahanNota = value; }
        }

        public int HargaBeli
        {
            get { return hargaBeli; }
            set { hargaBeli = value; }
        }

        public int JumlahBeli
        {
            get { return jumlahBeli; }
            set { jumlahBeli = value; }
        }
        public notaBeliDetail()
        {
            bahanNota = new bahan();
            hargaBeli = 0;
            jumlahBeli = 0;
        }

        public notaBeliDetail(bahan bhn, int hrg, int jml)
        {
            bahanNota = bhn;
            hargaBeli = hrg;
            jumlahBeli = jml;
        }

    }
}
