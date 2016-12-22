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
    }
}