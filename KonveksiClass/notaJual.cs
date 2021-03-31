using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class notaJual
    {
        private string noNota;
        private DateTime tanggal;
        private DateTime tanggalSelesai;
        private pelanggan pelanggan;
        private pegawai pegawai;
        private string status;
        private List<notaJualDetail> listNotaDetil;

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
        public DateTime TanggalSelesai
        {
            get { return tanggalSelesai; }
            set { tanggalSelesai = value; }
        }

        public pelanggan Pelanggan
        {
            get { return pelanggan; }
            set { pelanggan = value; }
        }

        public pegawai Pegawai
        {
            get { return pegawai; }
            set { pegawai = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public List<notaJualDetail> ListNotaDetil
        {
            get { return listNotaDetil; }
        }

        public int JumlahBarangNota
        {
            get { return listNotaDetil.Count; }
        }

        public notaJual()
        {
            noNota = "";
            tanggal = new DateTime();
            tanggalSelesai = new DateTime();
            pelanggan = new pelanggan();
            pegawai = new pegawai();
            status = "";
            List<notaJualDetail> listNotaDetil = new List<notaJualDetail>();
        }
        public notaJual(string no, string s)
        {
            noNota = no;
            status = s;
        }

        public notaJual(string nomor, DateTime tgl, DateTime tglselesai, pelanggan plg, pegawai pembuat, string stts, List<notaJualDetail> listNotaJualDetil)
        {
            noNota = nomor;
            tanggal = tgl;
            tanggalSelesai = tglselesai;
            pelanggan = plg;
            pegawai = pembuat;
            status = stts;
            listNotaDetil = listNotaJualDetil;
        }

    }
}
