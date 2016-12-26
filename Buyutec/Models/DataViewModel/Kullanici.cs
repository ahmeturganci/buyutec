using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataModel;
namespace Buyutec.Models.DataViewModel
{
    public class Kullanici
    {
        public int kullaniciId { get; set; }
        public string kullaniciAdi { get; set; }
        public string kullaniciSoyadi { get; set; }
        public string email { get; set; }
        public string sifre { get; set; }
        public string profilFoto { get; set; }
        public string hakkimda { get; set; }

        public static Kullanici MapData(tblKullanici k)
        {
            Kullanici kul = new Kullanici()
            {
                kullaniciId=k.kullaniciId,
                kullaniciAdi = k.kullaniciAdi,
                kullaniciSoyadi=k.kullaniciSoyadi,
                email=k.email,
                sifre=k.email,
                hakkimda=k.hakkimda,
                profilFoto=k.profilFoto
                
            };
            return kul;
        }
        public static tblKullanici MapData(Kullanici k)
        {
            tblKullanici kul = new tblKullanici()
            {
                kullaniciId = k.kullaniciId,
                kullaniciAdi = k.kullaniciAdi,
                kullaniciSoyadi = k.kullaniciSoyadi,
                email = k.email,
                sifre = k.email,
                hakkimda = k.hakkimda,
                profilFoto = k.profilFoto
            };
            return kul;
        }
        public static List<Kullanici> MapData(List<tblKullanici> RolList)
        {
            List<Kullanici> liste = new List<Kullanici>();

            foreach (var b in RolList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
        public static List<tblKullanici> MapData(List<Kullanici> KisiList)
        {
            List<tblKullanici> liste = new List<tblKullanici>();

            foreach (var b in KisiList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
    }
}