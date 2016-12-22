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
            return Json(KullaniciIslem.KullaniciGiris(kulMail, kulSifre));

        }
       public ActionResult Cikis()
        {
            //session çıkış
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
    }
}