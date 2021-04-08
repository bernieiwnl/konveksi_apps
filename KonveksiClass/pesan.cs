using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class pesan
    {
        private string idPesan;
        private pegawai idTujuan;
        private pegawai idPenerima;
        private string keterangan;

        public string IdPesan { get => idPesan; set => idPesan = value; }
        public pegawai IdTujuan { get => idTujuan; set => idTujuan = value; }
        public pegawai IdPenerima { get => idPenerima; set => idPenerima = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }

        public pesan()
        {
            this.idPesan = "";
            this.idTujuan = new pegawai();
            this.idPenerima = new pegawai();
            this.keterangan = "";
        }

        public pesan(string id, pegawai tujuan, pegawai penerima, string keterangan)
        {
            this.idPesan = id;
            this.idTujuan = tujuan;
            this.idPenerima = penerima;
            this.keterangan = keterangan;
        }


    }
}
