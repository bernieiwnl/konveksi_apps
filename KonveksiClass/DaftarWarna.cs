using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class DaftarWarna
    {
        private List<warna> listwarna;
        public List<warna> Listwarna { get => listwarna; set => listwarna = value; }
        public int JumlahWarna
        {
            get { return listwarna.Count; }
        }

        public DaftarWarna()
        {
            listwarna = new List<warna>();
        }

        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM warna";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    int id = int.Parse(data.GetValue(0).ToString());
                    string nama = data.GetValue(1).ToString();
                    warna w = new warna(id, nama);
                    listwarna.Add(w);
                }

                c.Dispose();
                data.Dispose();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
