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
        public Nullable<System.DateTime> olusturmaTarihi { get; set; }
        public Nullable<System.DateTime> baslangicTarihi { get; set; }
        public Nullable<System.DateTime> bitisTarihi { get; set; }
        public Nullable<decimal> butce { get; set; }
        public Nullable<bool> aktifMi { get; set; }

        public static Proje MapData(tblProje p)
        {
            Proje proje = new Proje()
            {
                projeId=p.projeId,
                projeAdi=p.projeAdi,
                projeAciklama=p.projeAciklama,
                olusturanKullaniciId=p.olusturanKullaniciId,
                olusturmaTarihi=p.olusturmaTarihi,
                bitisTarihi=p.bitisTarihi,
                butce=p.butce,
                aktifMi=p.aktifMi       
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
                olusturmaTarihi = p.olusturmaTarihi,
                bitisTarihi = p.bitisTarihi,
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