using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyutec.Models;
using Buyutec.IslerKatmani;
namespace Buyutec.Controllers
{
    public class ProjeController : Controller
    {
        public JsonResult ProjeEkle(tblProje proje)
        {
            //proje = new tblProje()
            //{
            //    projeAdi = proje.projeAdi,
            //    projeAciklama = proje.projeAciklama,
            //    butce = proje.butce,
            //    baslangicTarihi = proje.baslangicTarihi,
            //    bitisTarihi = proje.bitisTarihi,
            //    olusturanKullaniciId = proje.olusturanKullaniciId,
            //    olusturmaTarihi = proje.olusturmaTarihi,

            //};
            proje.aktifMi = true;
            //proje.olusturanKullaniciId = int.Parse(Session["kulId"].ToString());

            int s = ProjeIslem.ProjeEkle(proje);
            if (s == 0)
                return Json("+");
            else
                return Json("-");
        }
    }
}