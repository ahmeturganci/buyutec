using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataViewModel;
using Buyutec.Models.DataModel;

namespace Buyutec.IslerKatmani
{
    public class ProjeIslem
    {
        //Proje ekleme
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
        //Proje oluşturulan listeleme
        public static List<Proje> ProjeListele(int kulId)
        {
            List<Proje> projeler = new List<Proje>();
            try
            {
                BuyutecDBEntities db = new BuyutecDBEntities();
                var projeListe = (from k in db.tblProjes
                                  orderby k.olusturmaTarihi
                                  where k.olusturanKullaniciId == kulId
                                  select k);

                return Proje.MapData(projeListe.ToList()); ;
            }
            catch
            {
                return null;

            }

        }
        //Çalışılan projeleri listeleme
        public static List<Proje> CalisilanProjeListele(int kulId)
        {
            List<Proje> calisilanProje = new List<Proje>();
            try
            {
                BuyutecDBEntities db = new BuyutecDBEntities();
                var cListe = (from k in db.tblProjes
                              join c in db.tblKullaniciProjes on k.projeId equals c.projeId
                              orderby k.olusturmaTarihi
                              where c.kullaniciId == kulId
                              select k);


                return Proje.MapData(cListe.ToList()); ;
            }
            catch
            {
                return null;

            }
        }

        public static List<Proje> ProjeAra(string pAdi)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var aramaListe = (from k in db.tblProjes
                                      orderby k.olusturmaTarihi
                                      where k.projeAdi.Contains(pAdi)
                                      select k);
                    return Proje.MapData(aramaListe.ToList());
                }
            }
            catch
            {
                return null;
            }
        }

    }
}