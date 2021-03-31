using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class Koneksi
    {
        private MySqlConnection koneksi;
        private string namaServer;
        private string namaDatabase;
        private string username;
        private string password;

        #region properties
        public MySqlConnection KoneksiDB
        {
            get { return koneksi; }
        }
        public string NamaServer
        {
            get { return namaServer; }
            set { namaServer = value; }
        }
        public string NamaDatabase
        {
            get { return namaDatabase; }
            set { namaDatabase = value; }
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
        #endregion

        #region method

        public string Connect()
        {
            try
            {
                if (KoneksiDB.State == System.Data.ConnectionState.Open)
                {
                    KoneksiDB.Close();
                }
                KoneksiDB.Open();
                return "sukses";
            }

            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void UpdateAppConfig(String _stringKoneksi)
        {
            //Buka konfigurasi app.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //set app.config pada nama tag koneksi string yg dimasukkan pengguna
            config.ConnectionStrings.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString = _stringKoneksi;

            //simpan app.config yg diperbarui
            config.Save(ConfigurationSaveMode.Modified, true);

            //reload app.config dgn pengaturan baru
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        #endregion

        #region Constructor
        public Koneksi()
        {
            koneksi = new MySqlConnection();

            //set connection sesuai yg di app.config
            koneksi.ConnectionString = ConfigurationManager.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString;

            //panggil method konek
            string hasilConnect = Connect();
        }

        public Koneksi(string server, string database, string user, string pwd)
        {
            namaServer = server;
            namaDatabase = database;
            username = user;
            password = pwd;

            koneksi = new MySqlConnection();

            //Set connections sesuai dengan server yg dimasukkan
            String stringKoneksi = "server=" + namaServer + "; database=" + namaDatabase + "; uid= " + username + "; pwd=" + password;

            koneksi.ConnectionString = stringKoneksi;

            //panggil method konek
            string hasilConnect = Connect();

            if (hasilConnect == "sukses")
            {
                //ubah dgn memanggil methdo updtconfig
                UpdateAppConfig(stringKoneksi);
            }
        }
        #endregion
    }
}
