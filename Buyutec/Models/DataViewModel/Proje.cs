using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataModel;

namespace Buyutec.Models.DataViewModel
{
    public class Proje
    {
        public int projeId { get; set; }
        public string projeAdi { get; set; }
        public string projeAciklama { get; set; }
        public Nullable<int> olusturanKullaniciId { get; set; }
        public string olusturmaTarihi { get; set; }
        public string baslangicTarihi { get; set; }
        public string bitisTarihi { get; set; }
        public Nullable<decimal> butce { get; set; }
        public Nullable<bool> aktifMi { get; set; }

        public static Proje MapData(tblProje p)
        {
            Proje proje = new Proje()
            {
                projeId = p.projeId,
                projeAdi = p.projeAdi,
                projeAciklama = p.projeAciklama,
                olusturanKullaniciId = p.olusturanKullaniciId,
                olusturmaTarihi = p.olusturmaTarihi.ToString(),
                baslangicTarihi = p.baslangicTarihi.ToString(),
                bitisTarihi = p.bitisTarihi.ToString(),
                butce = p.butce,
                aktifMi = p.aktifMi
            };
            return proje;
        }

        public static tblProje MapData(Proje p)
        {
            tblProje proje = new tblProje()
            {
                projeId = p.projeId,
                projeAdi = p.projeAdi,
                projeAciklama = p.projeAciklama,
                olusturanKullaniciId = p.olusturanKullaniciId,
                olusturmaTarihi = Convert.ToDateTime(p.olusturmaTarihi),
                baslangicTarihi = Convert.ToDateTime(p.baslangicTarihi),
                bitisTarihi = Convert.ToDateTime(p.bitisTarihi),
                butce = p.butce,
                aktifMi = p.aktifMi
            };
            return proje;
        }
        public static List<Proje> MapData(List<tblProje> ProjeList)
        {
            List<Proje> liste = new List<Proje>();

            foreach (var b in ProjeList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
        public static List<tblProje> MapData(List<Proje> ProjeList)
        {
            List<tblProje> liste = new List<tblProje>();

            foreach (var b in ProjeList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }


    }
}