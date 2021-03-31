using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class warna
    {
        private int id;
        private string nama_warna;

        public int Id { get => id; set => id = value; }
        public string Nama_warna { get => nama_warna; set => nama_warna = value; }

        public warna()
        {
            this.id = 0;
            this.nama_warna = "";
        }

        public warna(int id, string nama_warna)
        {
            this.id = id;
            this.nama_warna = nama_warna;
        }



    }
}
