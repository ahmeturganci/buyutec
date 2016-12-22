using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models;
using System.Security.Cryptography;
using System.Text;

namespace Buyutec.IslerKatmani
{
    public class KullaniciIslem
    {
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
        public static int KullaniciKayit(tblKullanici kullanici)
        {
            try
            {
                BuyutecDBEntities db = new BuyutecDBEntities();

                var kul = (from k in db.tblKullanicis
                           where k.kullaniciAdi == kullanici.kullaniciAdi
                           select k).SingleOrDefault();

                if (kul == null)
                {
                    kullanici.sonGiris = DateTime.Now;
                    kullanici.sifre = MD5Sifrele(kullanici.sifre);
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
    }
}