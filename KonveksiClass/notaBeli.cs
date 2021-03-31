using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class notaBeli
    {
        private string noNota;
        private DateTime tanggal;
        private supplier supplier;
        private pegawai pegawai;
        private List<notaBeliDetail> listBeliDetil;


        public string NoNota
        {
            get { return noNota; }
            set { noNota = value; }
        }

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }

        public supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }

        public pegawai Pegawai
        {
            get { return pegawai; }
            set { pegawai = value; }
        }


        public List<notaBeliDetail> ListBeliDetil
        {
            get { return listBeliDetil; }
        }

        public int JumlahBarangNota
        {
            get { return listBeliDetil.Count; }
        }
        public notaBeli()
        {
            noNota = "";
            tanggal = new DateTime();
            supplier = new supplier();
            pegawai = new pegawai();
            List<notaBeliDetail> listBeliDetil = new List<notaBeliDetail>();
        }

        public notaBeli(string nomor, DateTime tgl, supplier supply, pegawai pembuat, List<notaBeliDetail> listNotaBeliDetil)
        {
            noNota = nomor;
            tanggal = tgl;
            supplier = supply;
            pegawai = pembuat;
            listBeliDetil = listNotaBeliDetil;
        }
    }
}
