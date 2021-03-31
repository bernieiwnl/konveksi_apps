using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class kegiatan
    {
        private string idKegiatan;
        private string namaKegiatan;

       

        public string IdKegiatan { get => idKegiatan; set => idKegiatan = value; }
        public string NamaKegiatan { get => namaKegiatan; set => namaKegiatan = value; }

        public kegiatan()
        {
            this.idKegiatan = "";
            this.namaKegiatan = "";
        }

        public kegiatan(string idKegiatan, string namaKegiatan)
        {
            this.idKegiatan = idKegiatan;
            this.namaKegiatan = namaKegiatan;
        }



    }
}
