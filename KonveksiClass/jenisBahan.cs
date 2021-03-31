using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class jenisBahan
    {
        private string id;
        private string nama_bahan;

        public string Nama_bahan { get => nama_bahan; set => nama_bahan = value; }
        public string Id { get => id; set => id = value; }

        public jenisBahan()
        {
            this.id = "";
            this.nama_bahan = "";
        }


        public jenisBahan(string id, string nama_bahan)
        {
            this.id = id;
            this.nama_bahan = nama_bahan;
        }

    }
}
