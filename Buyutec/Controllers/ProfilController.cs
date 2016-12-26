using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyutec.Models.DataModel;
using Buyutec.IslerKatmani;
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
        public JsonResult ProfilGuncelle(tblKullanici kul)
        {
            int kId = int.Parse(Session["kulId"].ToString());

            var sonuc = KullaniciIslem.ProfilGuncelle(kul,kId);
            if (sonuc == '+')
                return Json("+");
            else
                return Json("-");
        }
        
        public JsonResult SifreGuncelle(string eski,string yeni)
        {
            int kId = int.Parse(Session["kulId"].ToString());
            var sonuc = KullaniciIslem.SifreGuncelle(eski, yeni, kId);
            return Json(sonuc);
        }
        public JsonResult BilgiCek()
        {
            int kId = int.Parse(Session["kulId"].ToString());
            var sonuc = KullaniciIslem.BilgiCek(kId);
            return Json(sonuc);
        }




    }
}