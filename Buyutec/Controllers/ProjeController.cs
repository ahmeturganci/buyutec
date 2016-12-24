using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyutec.Models.DataModel;
using Buyutec.IslerKatmani;
namespace Buyutec.Controllers
{
    public class ProjeController : Controller
    {
        public static int projeId;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjeOlustur()
        {
            return View();
        }

        public ActionResult ProjeDetay(int id)
        {
            projeId = id;
            return View();
        }

        public JsonResult ProjeEkle(tblProje proje)
        {
            proje.aktifMi = true;
            int s = ProjeIslem.ProjeEkle(proje);
            if (s == 0)
                return Json("+");
            else
                return Json("-");
        }

        public JsonResult ProjeListele()
        {
            int kulId = int.Parse(Session["kulID"].ToString());
            var sList = ProjeIslem.ProjeListele(kulId);
            if (sList != null)
                return Json(sList);
            else
                return Json("-");
        }

        public JsonResult CalisilanProjeListele()
        {
            int kulId = int.Parse(Session["kulID"].ToString());
            var sList = ProjeIslem.CalisilanProjeListele(kulId);
            if (sList != null)
                return Json(sList);
            else
                return Json("-");
        }

        public JsonResult ProjeAra(string baslik)
        {
            var bList = ProjeIslem.ProjeAra(baslik);
            if (bList != null)
                return Json(bList);
            else
                return Json("-");
        }

        public JsonResult ProjeCek()
        {
            var sonuc = ProjeIslem.ProjeCek(projeId);
            return Json(sonuc.ToList());
        }

        public JsonResult DurumCek()
        {
            var sonuc = ProjeIslem.DurumListele();
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }

        public JsonResult OncelikListele()
        {
            var sonuc = ProjeIslem.OncelikListele();
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }

        public JsonResult KisiCek()
        {
            var sonuc = ProjeIslem.KisiCek();
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }

        public JsonResult SurecEkle(tblSurec veri, int kullaniciId)
        {
            veri.projeId = projeId;
            var sonuc = ProjeIslem.SurecEkle(veri, kullaniciId);
            if (sonuc == 0)
                return Json(sonuc);
            else
                return Json("-");

        }
    }
}