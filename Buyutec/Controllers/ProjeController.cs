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
    public class ProjeController : Controller
    {
        public static int projeDetayId;

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
            projeDetayId = id;
            return View();
        }

        public ActionResult ProjeSurecDetay()
        {
            return View();
        }
        //Proje oluşturma
        public JsonResult ProjeEkle(tblProje proje)
        {
            proje.aktifMi = true;
            char x = TarihKontrol(Convert.ToDateTime(proje.baslangicTarihi), Convert.ToDateTime(proje.olusturmaTarihi), Convert.ToDateTime(proje.bitisTarihi));
            if (x != '-')
                return Json(x);
            int s = ProjeIslem.ProjeEkle(proje);
            if (s == 0)
            {
                KullaniciProjeRol kpr = new KullaniciProjeRol
                {
                    projeId = proje.projeId,
                    kullaniciId = int.Parse(Session["kulId"].ToString()),
                    rolId = 1
                };
                KullaniciProjeEkle(kpr);
                Logar lg = new Logar((int)proje.olusturanKullaniciId, " Tarihte Proje Ekledi");
                return Json("+");
            }
            else
                return Json("-");
        }
        //Proje listeleme
        public JsonResult ProjeListele()
        {
            int kulId = int.Parse(Session["kulId"].ToString());
            var sList = ProjeIslem.ProjeListele(kulId);
            if (sList != null)
                return Json(sList);
            else
                return Json("-");
        }
        //çalışılan projelerin listelenmesi
        public JsonResult CalisilanProjeListele()
        {
            int kulId = int.Parse(Session["kulID"].ToString());
            var sList = ProjeIslem.CalisilanProjeListele(kulId);
            if (sList != null)
                return Json(sList);
            else
                return Json("-");
        }
        //proje arama işlemi !oluştudukları projede
        public JsonResult ProjeAra(string baslik)
        {
            var bList = ProjeIslem.ProjeAra(baslik);
            if (bList != null)
                return Json(bList);
            else
                return Json("-");
        }
        //proje verileri getirme
        public ActionResult error()
        {
            return View();
        }
        public JsonResult ProjeCek()
        {
            JsonResult jr = null;
            int kulId = int.Parse(Session["kulID"].ToString());
            var sonuc = ProjeIslem.ProjeCek(projeDetayId, kulId);
            if (sonuc == null)
            {
                jr = Json("null");
            }
            else
            {
                jr = Json(sonuc.ToList());
            }
            return jr;
            
        }
        //durumların listelenmesi
        public JsonResult DurumCek()
        {
            var sonuc = ProjeIslem.DurumListele();
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }
        //önceliklerin listelenmesi
        public JsonResult OncelikListele()
        {
            var sonuc = ProjeIslem.OncelikListele();
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }
        //kişi bilgilerinin listelenmesi
        public JsonResult KisiCek()
        {
            var sonuc = ProjeIslem.KisiCek();
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }
        //süreç ekleme
        public JsonResult SurecEkle(tblSurec veri)
        {
            veri.projeId = projeDetayId;
            char x = TarihKontrol(Convert.ToDateTime(veri.baslangicTarihi), Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(veri.bitisTarihi));
            if (x != '-')
                return Json(x);
            int kullaniciId = 0;
            if (Session["kulId"] != null)
                kullaniciId = int.Parse(Session["kulId"].ToString());
            else
                return Json('?'); // kullanıcı giriş yapmamış
            veri.bitirmeOrani = 0;
            var sonuc = ProjeIslem.SurecEkle(veri, kullaniciId);
            if (sonuc == 0)
            {
                Logar lg = new Logar(kullaniciId, " Tarihte Süreç Ekledi");
                return Json(sonuc);
            }
            else
                return Json("-");

        }
        //rollerin listelenmesi
        public JsonResult RolCek()
        {
            var rol = ProjeIslem.RolCek();
            if (rol != null)
                return Json(rol);
            else
                return Json('-');
        }
        //kullanıcıları projeye eklemek.
        public JsonResult KullaniciProjeEkle(KullaniciProjeRol veri)
        {
            veri.projeId = projeDetayId;
            var kpEkle = ProjeIslem.KullaniciProjeEkle(veri);
            if (kpEkle == 0)
                return Json(kpEkle);
            return Json('-');
        }
        //kullanıcı rollerini listeleme
        public JsonResult Rollerim(int projeId)
        {
            int kullaniciId = int.Parse(Session["kulId"].ToString());
            var rol = ProjeIslem.RolAdiCek(kullaniciId, projeId);
            if (rol != null)
                return Json(rol);
            return Json('-');
        }
        //süreç listeleme
        public JsonResult SurecListele()
        {
            var sonuc = ProjeIslem.SurecListele(projeDetayId);
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }
        //altsüreç listeleme
        public JsonResult AltSurecListele(int surecId)
        {
            var sonuc = ProjeIslem.AltSurecList(surecId);
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");

        }
        //süreç bilgileri 
        public JsonResult SurecCek(int sId)
        {
            var sonuc = ProjeIslem.SurecGetir(sId);
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }
        //altsüreç bilgileri
        public JsonResult AltSurecCek(int surecId)
        {
            var s = ProjeIslem.AltSurecGetir(surecId);
            if (s != null)
                return Json(s);
            else
                return Json('-');
        }
        //public JsonResult SureceKisiEkle(int kisiId, int )
        //altsüreç ekleme
        public JsonResult AltSurecEkle(tblAltSurec alt)
        {
            char x = TarihKontrol(Convert.ToDateTime(alt.baslangicTarihi), Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(alt.bitisTarihi));
            if (x != '-')
                return Json(x);
            alt.bitirmeOrani = 0;
            var s = ProjeIslem.AltSurecEkle(alt);
            if (s == 0)
            {
                int id = int.Parse(Session["kulId"].ToString());
                Logar lg = new Logar(id, " Tarihte Alt Süreç Ekledi");
                return Json("+");

            }
            else
                return Json("-");
        }
        //süreç güncelleme 
        public JsonResult SGuncelle(tblSurec ss, int sId)
        {
            var s = ProjeIslem.SurecGuncelle(ss, sId);
            return Json("+");
        }
        //alt süreç güncelleme
        public JsonResult AltSurecGuncelle(tblAltSurec alts, int aSId)
        {
            var sonuc = ProjeIslem.AltSurecGuncelle(alts, aSId);
            if (sonuc == '+')
                return Json('+');
            else
                return Json('-');
        }
        //
        public JsonResult ProjeKisiDoldur()//new { k.kullaniciId, k.kullaniciAdi, k.kullaniciSoyadi, p.projeId }
        {
            var sonuc = ProjeIslem.ProjeKisilerDoldur(projeDetayId);
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json('-');
        }
        //süreçe kişi atama
        public JsonResult SureceKisiAta(KullaniciSurec ks)
        {
            var sonuc = ProjeIslem.SureceKisiAta(ks,projeDetayId);
            if (sonuc == '+')
                return Json(sonuc);
            else
                return Json('-');
        }
        //projedeki çalışan kişileri listeleme
        //public JsonResult ProjeKisiListele()
        //{
        //    var sonuc = ProjeIslem.ProjeKisi();
        //    if (sonuc == 0)
        //        return Json("+");
        //    else
        //        return Json("-");
        //}
        public JsonResult SureceAtananKisileriCek(SureceAtananKisi sak)
        {
            var sonuc = ProjeIslem.SureceAtananKisileriCek(sak, projeDetayId);
            if (sonuc != null)
                return Json(sonuc);
            else
                return Json("-");
        }
        public JsonResult AltSureceKisiAta(KullaniciSurec ks)
        {
            var sonuc = ProjeIslem.AltSureceKisiAta(ks, projeDetayId);
            if (sonuc == '+')
                return Json(sonuc);
            else
                return Json("-");
        }
        public char TarihKontrol(DateTime dt, DateTime dto,DateTime dtb) // dt başlangıç, dto oluşturma, dtb bitiş
        {
            char res = '-';
            DateTime tarih = DateTime.ParseExact("2000-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
            if (dt > tarih && dtb > tarih)
            {
                if (dt <= dto && dt >= dtb)
                    res = '_';
                else if (dtb <= dt && dtb <= dt)
                    res = '/';
            }
            else
                res = 't';
            return res;

        }
    }
}