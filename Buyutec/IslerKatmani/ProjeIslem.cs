using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models;

namespace Buyutec.IslerKatmani
{
    public class ProjeIslem
    {
        public static int ProjeEkle(tblProje proje)
        {
            try
            {
                BuyutecDBEntities db = new BuyutecDBEntities();

                var p = (from k in db.tblProjes
                           where k.projeAdi == null
                           select k).SingleOrDefault();

                if (p == null)
                {
                    db.tblProjes.Add(proje);
                    db.SaveChanges();
                    return 0; // proje ekleme başarılı
                }
                else
                    return 1; //proje başarısız
            }
            catch
            {
                return 2; // işlem başarısız
            }
        }
        public static List<tblProje> ProjeListele(int kulId)
        {
            List<tblProje> projeler = new List<tblProje>();
            try
            {
                BuyutecDBEntities db = new BuyutecDBEntities();
                var projeListe = (from k in db.tblProjes
                                  where k.olusturanKullaniciId == kulId
                                  select k);
                foreach (var item in projeListe)
                {
                    projeler.Add(item);
                }
                return projeler;
            }
            catch
            {
                return null;

            }

        }
    }
}