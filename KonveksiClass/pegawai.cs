using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class pegawai
    {
        private string kodePegawai;
        private string nama;
        private DateTime tglLahir;
        private string alamat;
        private string gaji;
        private string username;
        private string password;
        private jabatan jabatanPegawai;

        public string KodePegawai
        {
            get { return kodePegawai; }
            set { kodePegawai = value; }
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public DateTime TglLahir
        {
            get { return tglLahir; }
            set { tglLahir = value; }
        }

        public string TanggalLahir
        {
            get { return tglLahir.ToString("yyyy-MM-dd"); }
        }

        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        public string Gaji
        {
            get { return gaji; }
            set { gaji = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string IdJabatanPegawai
        {
            get { return jabatanPegawai.IdJabatan; }
            set { IdJabatanPegawai = value; }
        }

        public string NamaJabatanPegawai
        {
            get { return jabatanPegawai.NamaJabatan; }
            set { NamaJabatanPegawai = value; }
        }

        public jabatan JabatanPegawai
        {
            get { return jabatanPegawai; }
            set { jabatanPegawai = value; }
        }

        public pegawai()
        {
            kodePegawai = "";
            nama = "";
            tglLahir = DateTime.Now;
            alamat = "";
            gaji = "";
            username = "";
            password = "";
            jabatanPegawai = new jabatan();
        }

        public pegawai(string kode, string namaP, DateTime tgl, string almt, string gj, string user, string pass, jabatan jab)
        {
            kodePegawai = kode;
            nama = namaP;
            tglLahir = tgl;
            alamat = almt;
            gaji = gj;
            username = user;
            password = pass;
            jabatanPegawai = jab;

        }
    }
}
