using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class pekerjaan
    {
        private string idPengerjaan;
        private kegiatan kegiatan;
        private pegawai pegawai;
        private DateTime tanggalKegiatan;
        private string keterangan;
        private string status;
        private barang barang;
        private int harga;
        private int satuan;

        public string IdPengerjaan { get => idPengerjaan; set => idPengerjaan = value; }
        public kegiatan Kegiatan { get => kegiatan; set => kegiatan = value; }
        public pegawai Pegawai { get => pegawai; set => pegawai = value; }
        public DateTime TanggalKegiatan { get => tanggalKegiatan; set => tanggalKegiatan = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public string Status { get => status; set => status = value; }
        public int Harga { get => harga; set => harga = value; }
        public int Satuan { get => satuan; set => satuan = value; }
        public barang Barang { get => barang; set => barang = value; }

        public pekerjaan()
        {
            this.idPengerjaan = "";
            this.kegiatan = new kegiatan();
            this.pegawai = new pegawai();
            this.tanggalKegiatan = new DateTime();
            this.keterangan = "";
            this.status = "";
            this.Barang = new barang();
            this.harga = 0;
            this.satuan = 0;
        
        }

        public pekerjaan(string idPengerjaan, kegiatan kegiatan, pegawai pegawai, DateTime tanggalKegiatan, string keterangan, string status, int harga, int satuan, barang barang)
        {
            this.IdPengerjaan = idPengerjaan;
            this.Kegiatan = kegiatan;
            this.Pegawai = pegawai;
            this.TanggalKegiatan = tanggalKegiatan;
            this.Keterangan = keterangan;
            this.Status = status;
            this.harga = harga;
            this.satuan = satuan;
            this.barang = barang;
            
        }
    }
}
