using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyutec.IslerKatmani;
using Buyutec.Models.DataModel;
namespace Buyutec.Controllers
{
    public class HomeController : Controller
    {
        //Sayfa
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Kayitol()
        {
            return View();
        }
        //Giriş
        public JsonResult GirisYapKullanici(string kulMail, string kulSifre)
        {
            if (kulMail == "" || kulSifre == "")
            {
                return Json("-");
            }
            char c = KullaniciIslem.KullaniciGiris(kulMail, kulSifre);
            if (c == '+')
            {
                var sessionKulId = KullaniciIslem.KullaniciVer(kulMail);
                Session.Add("kulId", sessionKulId.kullaniciId);
                Session.Add("kulAd", sessionKulId.kullaniciAdi);
                Session.Add("kulMail", sessionKulId.email);
                tblLog logDegerler = new tblLog();
                logDegerler.kullaniciId = sessionKulId.kullaniciId;
                logDegerler.logBilgisi = "Kullanıcı"+DateTime.Now+"Tarihte Giriş Yaptı";
                KullaniciIslem.HareketEkle(logDegerler);
            }



            
            return Json(c);

        }
        //Son sistemde ki hareketleri 
        public ActionResult SonHareketler()
        {
            return View();//log için
        }
        //sistem hareketleri çekmek
        public JsonResult HareketListele()
        {
            var liste = KullaniciIslem.HareketListele();
            return Json(liste);
        }
        //Çıkış
        public ActionResult Cikis()
        {
            //session çıkış
            Session.Remove("kulMail");
            return View("Index");
        }
        //kayıt ol
        public JsonResult KayitOlKullanici(tblKullanici kul)
        {
            int sonuc = KullaniciIslem.KullaniciKayit(kul);
            if (sonuc == 0)
                return Json("+");
            else
                return Json("-");
        }


    }
}