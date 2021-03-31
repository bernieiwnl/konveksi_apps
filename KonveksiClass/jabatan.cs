using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace KonveksiClass
{
    public class jabatan
    {
        private string idJabatan;
        private string namaJabatan;

        public string IdJabatan
        {
            get { return idJabatan; }
            set { idJabatan = value; }
        }

        public string NamaJabatan
        {
            get { return namaJabatan; }
            set { namaJabatan = value; }
        }

        public jabatan()
        {
            idJabatan = "";
            namaJabatan = "";
        }

        public jabatan(string id, string nama)
        {
            idJabatan = id;
            namaJabatan = nama;
        }
    }
}
