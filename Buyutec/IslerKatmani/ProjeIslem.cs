using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataViewModel;
using Buyutec.Models.DataModel;
using Buyutec.Models.Helper;

namespace Buyutec.IslerKatmani
{
    public class ProjeIslem
    {
        //Proje ekleme
        public static int ProjeEkle(tblProje proje)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var p = (from k in db.tblProjes
                             where k.projeAdi == null
                             select k).SingleOrDefault();

                    if (p == null)
                    {
                        db.tblProjes.Add(proje);
                        db.SaveChanges();
                        return 0; // proje ekleme başarılı
                    }
                    else
                        return 1; //proje başarısız
                }
            }
            catch
            {
                return 2; // işlem başarısız
            }
        }
        //Proje oluşturulan listeleme
        public static List<Proje> ProjeListele(int kulId)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var projeListe = (from k in db.tblProjes
                                      orderby k.olusturmaTarihi
                                      where k.olusturanKullaniciId == kulId
                                      select k);
                    return Proje.MapData(projeListe.ToList());
                }
            }
            catch
            {
                return null;

            }

        }
        //Çalışılan projeleri listeleme
        public static List<Proje> CalisilanProjeListele(int kulId)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var cListe = (from k in db.tblProjes
                                  join c in db.tblKullaniciProjeRols on k.projeId equals c.projeId
                                  orderby k.olusturmaTarihi
                                  where c.kullaniciId == kulId
                                  select k);

                    return Proje.MapData(cListe.ToList());
                }
            }
            catch
            {
                return null;

            }
        }
        //proje arama
        public static List<Proje> ProjeAra(string pAdi)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var aramaListe = (from k in db.tblProjes
                                      orderby k.olusturmaTarihi
                                      where k.projeAdi.Contains(pAdi)
                                      select k);
                    return Proje.MapData(aramaListe.ToList());
                }
            }
            catch
            {
                return null;
            }
        }
        //süreç listeleme
        public static List<Surec> SurecListele(int pId)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var surecL = (from s in db.tblSurecs
                                  orderby s.baslangicTarihi
                                  where s.projeId == pId
                                  select s);
                    return Surec.MapData(surecL.ToList());
                }

            }
            catch
            {
                return null;
            }
        }
        //altsüreç listeleme
        public static List<AltSurec> AltSurecList(int sId)
        {

            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var altSurL = (from a in db.tblAltSurecs
                                   orderby a.baslangicTarihi
                                   where a.surecId == sId
                                   select a
                                   );
                    return AltSurec.MapData(altSurL.ToList());
                }
            }
            catch
            {

                return null;
            }
        }
        //süreç ekle
        public static int SurecEkle(tblSurec surec, int kullaniciId)//??!!zzzBAMM ;)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    db.tblSurecs.Add(surec);

                    tblKullaniciSurec ks = new tblKullaniciSurec();
                    ks.surecId = surec.surecId;
                    ks.kullaniciId = kullaniciId;
                    surec.tblKullaniciSurecs.Add(ks);

                    db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 1; // işlem başarısız
            }
        }
        //altsüreç ekle
        public static int AltSurecEkle(tblAltSurec altSurec)//??!!
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    

                    tblKullaniciAltSurec kas = new tblKullaniciAltSurec();
                    //kas.altSurecId = altSurec.altSurecId;
                    altSurec.tblKullaniciAltSurecs.Add(kas);
                    db.tblAltSurecs.Add(altSurec);
                    db.SaveChanges();
                }
                return 0;
            }
            catch(Exception ex)
            {
                return 1; // işlem başarısız
            }
        }
        //rol listele
        public static List<Rol> RolListele()
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var rolListe = (from r in db.tblRols
                                    orderby r.rolAdi
                                    select r);
                    return Rol.MapData(rolListe.ToList());
                }
            }
            catch
            {
                return null;
            }
        }
        //durum listele
        public static List<Durum> DurumListele()
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var durumListe = (from r in db.tblDurums
                                      orderby r.durumAdi
                                      select r);
                    return Durum.MapData(durumListe.ToList());
                }
            }
            catch
            {
                return null;
            }
        }
        //oncelik listele
        public static List<Oncelik> OncelikListele()
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var oncelikL = (from o in db.tblOnceliks
                                    orderby o.oncelikAdi
                                    select o);
                    return Oncelik.MapData(oncelikL.ToList());
                }
            }
            catch
            {
                return null;

            }
        }
        //proje getir
        public static List<Proje> ProjeCek(int projeId)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var p = (from pc in db.tblProjes
                             where pc.projeId == projeId
                             select pc);
                    return Proje.MapData(p.ToList());
                }
            }
            catch
            {

                return null;
            }
        }
        //KullaniciListele
        public static List<Kullanici> KisiCek()
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var p = (from pc in db.tblKullanicis
                             orderby pc.kullaniciAdi
                             select pc);
                    return Kullanici.MapData(p.ToList());
                }
            }
            catch
            {

                return null;
            }
        }
        public static List<Rol> RolCek()
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var veri = db.tblRols;
                    return Rol.MapData(veri.ToList());
                }
            }
            catch (Exception ex) // ex debug modda hata içeriği için
            {
                return null;
            }
        }

        public static int KullaniciProjeEkle(KullaniciProjeRol veri)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var sonuc = (from p in db.tblKullaniciProjeRols where p.projeId == veri.projeId && p.kullaniciId == veri.kullaniciId && p.rolId != veri.rolId select p).SingleOrDefault();
                    if (sonuc == null)
                    {
                        tblKullaniciProjeRol kp = new tblKullaniciProjeRol
                        {
                            projeId = veri.projeId,
                            kullaniciId = veri.kullaniciId,
                            rolId = veri.rolId
                        };
                        db.tblKullaniciProjeRols.Add(kp);
                        db.SaveChanges();
                        return 0;
                    }
                    else
                        return 2;

                }
            }
            catch (Exception ex)
            {

                return 1;
            }
        }
        public static List<string> RolAdiCek(int kullaniciId, int projeId)
        {
            try
            {
                List<string> rollerim = new List<string>();
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var rolCek = (from p in db.tblKullaniciProjeRols join o in db.tblRols on p.rolId equals o.rolId where p.kullaniciId == kullaniciId && p.projeId == projeId select new { o.rolAdi });
                    foreach (var item in rolCek)
                    {
                        rollerim.Add(item.rolAdi);
                    }
                }
                return rollerim;
            }
            catch
            {

                return null;
            }
        }
        public static List<Surec> SurecGetir(int sId)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var istenenSurec = (from s in db.tblSurecs
                                        where s.surecId == sId
                                        select s);
                    return Surec.MapData(istenenSurec.ToList());
                }
            }
            catch
            {

                return null;
            }
        }
        public static List<AltSurec> AltSurecGetir(int surecId)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var altSurec = (from p in db.tblAltSurecs where p.surecId == surecId select p);
                    return AltSurec.MapData(altSurec.ToList());
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static char SurecGuncelle(tblSurec surec, int surecId)
        {
            char sonuc = '*';
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var s = db.tblSurecs.Find(surecId);
                    if (s != null)
                    {
                        s.surecAdi = surec.surecAdi;
                        s.oncelikId = surec.oncelikId;
                        s.durumId = surec.durumId;
                        s.bitirmeOrani = surec.bitirmeOrani;
                        s.aciklama = surec.aciklama;
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

        public static char AltSurecGuncelle(tblAltSurec altSurec, int altSurecId)
        {
            char sonuc = '*';
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var s = db.tblAltSurecs.Find(altSurecId);
                    if (s != null)
                    {
                        s.altSurecAdi = altSurec.altSurecAdi;
                        s.oncelikId = altSurec.oncelikId;
                        s.durumId = altSurec.durumId;
                        s.bitirmeOrani = altSurec.bitirmeOrani;
                        s.aciklama = altSurec.aciklama;
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
    }
}