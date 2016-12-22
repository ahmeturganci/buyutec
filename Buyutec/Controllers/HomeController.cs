using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyutec.IslerKatmani;
using Buyutec.Models;
namespace Buyutec.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //session 
            return View();
        }
        public JsonResult Giris(string kulMail, string kulSifre)
        {
            if (kulMail == " " || kulSifre == " ")
            {
                return Json("-");
            }
            char c = KullaniciIslem.KullaniciGiris(kulMail, kulSifre);
            if (c == '+')
            {
                var sessionKulId = KullaniciIslem.KullaniciVer(kulMail);
                Session.Add("kulId", sessionKulId.kullaniciId);
                Session.Add("kulMail", kulMail);
            }
            return Json(c);

        }
       public ActionResult Cikis()
        {
            //session çıkış
            Session.Remove("kulMail");
            return View("Index");
        }
        public JsonResult KayitOl(tblKullanici kul)
        {
            int sonuc = KullaniciIslem.KullaniciKayit(kul);
            if (sonuc == 0)
                return Json("+");
            else
                return Json("-");
        }

        public ActionResult ProjeOlustur()
        {
            return View();
        }
       
    }
}