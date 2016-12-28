using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyutec.Models.DataModel;
using Buyutec.IslerKatmani;
using Buyutec.Models.Helper;

namespace Buyutec.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            if (Session["kulMail"] == null)
                Response.Redirect("/Home/Index");
            return View();
        }
        //Profil Güncelleme 
        public JsonResult ProfilGuncelle(tblKullanici kul)
        {
            int kId = int.Parse(Session["kulId"].ToString());
            Logar lg = new Logar(kId, " Tarihte Profil Güncelledi");
            var sonuc = KullaniciIslem.ProfilGuncelle(kul,kId);
            if (sonuc == '+')
                return Json("+");
            else
                return Json("-");
        }
        //Şifre Değiştirme
        public JsonResult SifreGuncelle(string eski,string yeni)
        {
            int kId = int.Parse(Session["kulId"].ToString());
            Logar lg = new Logar(kId, " Tarihte Şifre Güncelledi");
            var sonuc = KullaniciIslem.SifreGuncelle(eski, yeni, kId);
            return Json(sonuc);
        }
        //Kullanıcı Profil Bilgisi Çekme
        public JsonResult BilgiCek()
        {
            int kId = int.Parse(Session["kulId"].ToString());
            var sonuc = KullaniciIslem.BilgiCek(kId);
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }




    }
}