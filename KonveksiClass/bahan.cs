using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class bahan
    {
        private string id;
        private string namaBahan;
        private int stok;
        private int hargaBeli;
        private warna warna;
        private jenisBahan jenis_bahan;
        private satuan satuan;
        private int minimal;

        public string Id { get => id; set => id = value; }
        public string NamaBahan { get => namaBahan; set => namaBahan = value; }
        public int Stok { get => stok; set => stok = value; }
        public int HargaBeli { get => hargaBeli; set => hargaBeli = value; }
        public warna Warna { get => warna; set => warna = value; }
        public jenisBahan Jenis_bahan { get => jenis_bahan; set => jenis_bahan = value; }
        public satuan Satuan { get => satuan; set => satuan = value; }
        public int Minimal { get => minimal; set => minimal = value; }

        public bahan()
        {
            this.id = "";
            this.namaBahan = "";
            this.stok = 0;
            this.hargaBeli = 0;
            this.Jenis_bahan = null;
            this.Warna = null;
            this.satuan = null;
            this.minimal = 0;
        }

        public bahan(string id, string namaBahan, int stok, int hargaBeli, warna warna , jenisBahan jenis_bahan, satuan satuan, int minimal)
        {
            this.id = id;
            this.namaBahan = namaBahan;
            this.stok = stok;
            this.hargaBeli = hargaBeli;
            this.Warna = warna;
            this.Jenis_bahan = jenis_bahan;
            this.satuan = satuan;
            this.minimal = minimal;
            
        }
    }
}
