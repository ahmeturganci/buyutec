using Buyutec.IslerKatmani;
using Buyutec.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buyutec.Models.Helper
{
    public class Logar
    {
        public Logar(int kulId,string aciklama)
        {
            tblLog log = new tblLog()
            {
                kullaniciId = kulId,
                logBilgisi = "Kullanıcı " + DateTime.Now + aciklama
            };
            KullaniciIslem.HareketEkle(log);
        }
            
    }
}