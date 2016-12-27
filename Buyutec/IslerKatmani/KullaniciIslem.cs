using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataModel;
using System.Security.Cryptography;
using System.Text;
using Buyutec.Models.DataViewModel;
namespace Buyutec.IslerKatmani
{
    public class KullaniciIslem
    {
        //MD5 şifreleme
        public static string MD5Sifrele(string metin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
        //kullanıcı giriş 
        public static char KullaniciGiris(string kulMail, string sifre)
        {
            try
            {
                sifre = MD5Sifrele(sifre);
                BuyutecDBEntities db = new BuyutecDBEntities();

                var k = (from kul in db.tblKullanicis
                         where kul.email == kulMail && kul.sifre == sifre //email ve şifre dogrulaması.
                         select kul).SingleOrDefault();

                if (k == null)
                {
                    return '-';
                }
                else
                {
                    return '+';
                }
            }
            catch (Exception ex)
            {
                return '?';
            }
        }
        //kullanıcı kayıt
        public static int KullaniciKayit(tblKullanici kullanici)
        {
            try
            {
                BuyutecDBEntities db = new BuyutecDBEntities();

                var kul = (from k in db.tblKullanicis
                           where k.email == kullanici.email
                           select k).SingleOrDefault();

                if (kul == null)
                {
                    kullanici.sifre = MD5Sifrele(kullanici.sifre);
                    kullanici.profilFoto = "https://upload.wikimedia.org/wikipedia/commons/d/d5/Simpleicons_Interface_magnifier-on-a-user.svg";
                    kullanici.hakkimda = "Büyüteç PYS sistem kullanıcısı";
                    db.tblKullanicis.Add(kullanici);
                    db.SaveChanges();

                    return 0; // kayıt başarılı
                }
                else
                    return 1; // kayıt başarısız
            }
            catch
            {
                return 2; // işlem başarısız
            }
        }
        //profil güncelleme
        public static char ProfilGuncelle(tblKullanici kul,int kId)
        {
            try
            {
                char res = '*';
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var kullanici = (from k in db.tblKullanicis
                                     where k.kullaniciId == kId
                                     select k).SingleOrDefault();
                    if (kullanici != null)
                    {
                        kullanici.kullaniciAdi = kul.kullaniciAdi;
                        kullanici.kullaniciSoyadi = kul.kullaniciSoyadi;
                        kullanici.profilFoto = kul.profilFoto;
                        kullanici.hakkimda = kul.hakkimda;
                        db.SaveChanges();
                        res = '+';
                    }
                    else
                        res = '-';

                    return res;


                }
            }
            catch
            {
                return '?';
            }
        }
        //istenilen kullanıcı getirme
        public static tblKullanici KullaniciVer(string mail)
        {

            try
            {

                BuyutecDBEntities db = new BuyutecDBEntities();

                var k = (from kul in db.tblKullanicis
                         where kul.email == mail //email ve şifre dogrulaması.
                         select kul).FirstOrDefault();

                tblKullanici kk = new tblKullanici()
                {
                    kullaniciAdi = k.kullaniciAdi,
                    kullaniciSoyadi = k.kullaniciSoyadi,
                    sifre = k.sifre,
                    email = k.email,
                    kullaniciId = k.kullaniciId

                };
                return kk;
            }
            catch
            {
                return null;
            }
        }
        //şifre güncelleme
        public static char SifreGuncelle(string eski, string yeni, int kId)
        {
            char sonuc = '*';
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    eski = MD5Sifrele(eski);
                    var kulS = db.tblKullanicis.Find(kId);
                    if (kulS.sifre == eski)
                    {
                        kulS.sifre = MD5Sifrele(yeni);
                        db.SaveChanges();
                        sonuc = '+';
                    }
                    else
                        sonuc = '-';

                }
                return sonuc;

            }
            catch
            {
                sonuc = '?';
            }
            return sonuc;
        }
        //kullanıcı bilgileri listeleme
        public static List<Kullanici> BilgiCek(int kId)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var bilgiL = (from k in db.tblKullanicis
                                  where k.kullaniciId == kId
                                  select k);
                    return Kullanici.MapData(bilgiL.ToList());
                }
            }
            catch
            {
                return null;
            }
        }
        //kullanıcı hareketleri /loglama işlemi için
        public static char HareketEkle(tblLog log)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    db.tblLogs.Add(log);
                    db.SaveChanges();
                    return '+';
                }
                
            }
            catch 
            {

                return '-';
            }
        }
        //hareketleri listelemek
        public static List<Log> HareketListele()
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var liste = (from l in db.tblLogs select l);
                    return Log.MapData(liste.ToList());
                }

            }
            catch 
            {

                throw;
            }
        }
    }
}