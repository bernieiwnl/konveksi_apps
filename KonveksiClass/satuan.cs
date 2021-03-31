using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class satuan
    {
        private string id;
        private string namaSatuan;

        public string Id { get => id; set => id = value; }
        public string NamaSatuan { get => namaSatuan; set => namaSatuan = value; }

        public satuan()
        {
            this.id = "";
            this.namaSatuan = "";
        }

        public satuan(string id, string namaSatuan)
        {
            this.id = id;
            this.namaSatuan = namaSatuan;
        }
    }
}
