using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class notaBeliUpdate
    {
        private string noNota;
        private DateTime tanggal;
        private supplier supplier;
        private pegawai pegawai;
        private notaBeliDetail listBeliDetil;


        public string NoNota
        {
            get { return noNota; }
            set { noNota = value; }
        }

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }

        public supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }

        public pegawai Pegawai
        {
            get { return pegawai; }
            set { pegawai = value; }
        }

        public notaBeliDetail ListBeliDetil { get => listBeliDetil; set => listBeliDetil = value; }

        public notaBeliUpdate()
        {
            noNota = "";
            tanggal = new DateTime();
            supplier = new supplier();
            pegawai = new pegawai();
            listBeliDetil = new notaBeliDetail();
        }

        public notaBeliUpdate(string nomor, DateTime tgl, supplier supply, pegawai pembuat, notaBeliDetail notaBeliDetail)
        {
            noNota = nomor;
            tanggal = tgl;
            supplier = supply;
            pegawai = pembuat;
            listBeliDetil = notaBeliDetail;
        }
    }
}
