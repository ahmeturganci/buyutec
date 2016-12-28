using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyutec.IslerKatmani;
using Buyutec.Models.DataModel;
using Buyutec.Models.Helper;

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
                //kullanıcı sisteme giriş yaptııııı

                int id = int.Parse(Session["kulId"].ToString());
                Logar lg = new Logar(id, " Tarihte Giriş Yaptı");
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
            int kullaniciId = int.Parse(Session["kulId"].ToString());
            var liste = KullaniciIslem.HareketListele(kullaniciId);
            return Json(liste);
        }
        //Çıkış
        public ActionResult Cikis()
        {
            int id = int.Parse(Session["kulId"].ToString());
            Logar lg = new Logar(id, " Tarihte Çıkış Yaptı");
            //session çıkış
            Session.Remove("kulMail");
            Session.Remove("kulId");
            Session.Remove("kulAd");
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