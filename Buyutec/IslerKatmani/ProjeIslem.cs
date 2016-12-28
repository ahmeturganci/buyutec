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
            var pp = (dynamic)null;
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var projeListe = (from k in db.tblProjes
                                      orderby k.olusturmaTarihi
                                      where k.olusturanKullaniciId == kulId
                                      select k);
                    pp= Proje.MapData(projeListe.ToList());
                }
                return pp;
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
                                  where c.kullaniciId == kulId && c.kullaniciId==kulId
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
        public static List<Proje> ProjeCek(int projeId,int kullaniciId)
        {
            var pp = (dynamic)null;
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var projedemisin = (from p in db.tblKullaniciProjeRols where p.projeId == projeId && p.kullaniciId == kullaniciId select p).FirstOrDefault();
                    var projeOlusturanmisin = (from p in db.tblProjes where p.projeId == projeId && p.olusturanKullaniciId == kullaniciId select p).FirstOrDefault();
                    if (projedemisin != null || projeOlusturanmisin !=null)
                    {
                        var p = (from pc in db.tblProjes
                                 where pc.projeId == projeId
                                 select pc);
                        pp = Proje.MapData(p.ToList());
                    }
                }
            }
            catch(Exception ex)
            {

                pp = null;
            }
            return pp;
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
        //rol listeleme
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
        // kişi atama
        public static int KullaniciProjeEkle(KullaniciProjeRol veri)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var sonuc = (from p in db.tblKullaniciProjeRols where p.projeId == veri.projeId && p.kullaniciId == veri.kullaniciId && p.rolId == veri.rolId select p).SingleOrDefault();
                    if (sonuc == null)
                    {
                        //var rolvarmi=(from p in db.tblKullaniciProjeRols where )
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
        //kullanıcı rolleri çekmek
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
        // süreç bilgileri
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
        //altsüreç bilgileri
        public static List<AltSurec> AltSurecGetir(int surecId)
        {
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var altSurec = (from p in db.tblAltSurecs where p.altSurecId == surecId select p);
                    return AltSurec.MapData(altSurec.ToList());
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        //süreç güncelleme
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
        //altsüreç güncelleme
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
        // projede çalışan kişileri listelemej
        public static List<Kullanici> ProjeKisilerDoldur(int projeId)
        {
            try
            {
                using (BuyutecDBEntities db=new BuyutecDBEntities())
                {
                    var kisilerim = (from k in db.tblKullanicis join p in db.tblKullaniciProjeRols on k.kullaniciId equals p.kullaniciId where p.projeId == projeId select k);
                       return Kullanici.MapData(kisilerim.ToList());
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        //süreçe kişi atamak
        public static char SureceKisiAta(KullaniciSurec ks, int projeId)
        {
            char res = '-';
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var projeSurecKontrol = (from p in db.tblSurecs where p.projeId == projeId && p.surecId == ks.surecId select p).SingleOrDefault();
                    if (projeSurecKontrol != null)
                    {
                        var surecKullaniciKontrol = (from p in db.tblKullaniciSurecs where p.kullaniciId == ks.kullaniciId && p.surecId == ks.surecId select p).SingleOrDefault();
                        if (surecKullaniciKontrol == null)
                        {
                            tblKullaniciSurec tks = new tblKullaniciSurec
                            {
                                kullaniciId = ks.kullaniciId,
                                surecId = ks.surecId,
                            };
                            db.tblKullaniciSurecs.Add(tks);
                            db.SaveChanges();
                            res = '+';
                        }
                    }
                    return res;
                }
            }
            catch (Exception ex)
            {

                return '?';
            }
        }
        //projede çalışan kişiler
        //public static int ProjeKisi()
        //{
        //    try
        //    {
        //        using (BuyutecDBEntities db = new BuyutecDBEntities())
        //        {
        //            var kl = (from kkk in db.tblKullanicis
        //                      select kkk);// gelecek şart
        //            return 0;
        //        }
                
        //    }
        //    catch (Exception)
        //    {
        //        return 1;
        //        throw;
        //    }
                    
        //}
        public static List<Kullanici> SureceAtananKisileriCek(SureceAtananKisi sak, int projeId)
        {
            var kullanicilar = (dynamic)null;
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    if (sak.surec == 1) {
                        var projeSurecKontrol = (from p in db.tblSurecs where p.projeId == projeId && p.surecId == sak.Id select p).SingleOrDefault();
                        if (projeSurecKontrol != null)
                        {
                            var surecSonuc = (from p in db.tblKullaniciSurecs join k in db.tblKullanicis on p.kullaniciId equals k.kullaniciId where p.surecId == sak.Id select k);
                            if (surecSonuc != null)
                                kullanicilar = Kullanici.MapData(surecSonuc.ToList());
                        }
                    }
                    else if(sak.surec == 2)
                    {
                        var projeAltSurecKontrol = (from p in db.tblAltSurecs where p.altSurecId == sak.Id select new { p.surecId }).SingleOrDefault();
                        if(projeAltSurecKontrol != null)
                        {
                            var projeSurecKontrol = (from p in db.tblSurecs where p.projeId == projeId && p.surecId == projeAltSurecKontrol.surecId select p).SingleOrDefault();
                            if(projeSurecKontrol != null)
                            {
                                var altsurecSonuc = (from p in db.tblKullaniciAltSurecs join k in db.tblKullanicis on p.kullaniciId equals k.kullaniciId where p.altSurecId == sak.Id select k);
                                if (altsurecSonuc != null)
                                    kullanicilar = Kullanici.MapData(altsurecSonuc.ToList());

                            }
                        }
                    }
                }
                return kullanicilar;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static char AltSureceKisiAta(KullaniciSurec ks , int projeId)
        {
            char result = '-';
            try
            {
                using (BuyutecDBEntities db = new BuyutecDBEntities())
                {
                    var altSurecKontrol = (from p in db.tblAltSurecs where p.altSurecId == ks.surecId select new { p.surecId }).SingleOrDefault();
                    if (altSurecKontrol != null)
                    {
                        var surecProjeKontrol = (from p in db.tblSurecs where p.surecId == altSurecKontrol.surecId && p.projeId == projeId select p).SingleOrDefault();
                        if (surecProjeKontrol != null)
                        {
                            var kullaniciSurectevarmi = (from p in db.tblKullaniciSurecs where p.surecId == altSurecKontrol.surecId && p.kullaniciId == ks.kullaniciId select p).SingleOrDefault();
                            if (kullaniciSurectevarmi == null)
                            {
                                tblKullaniciSurec kss = new tblKullaniciSurec
                                {
                                    surecId = (int)altSurecKontrol.surecId,
                                    kullaniciId = ks.kullaniciId
                                };
                                db.tblKullaniciSurecs.Add(kss);
                            }
                            var kullanicivarmi = (from p in db.tblKullaniciAltSurecs where p.altSurecId == ks.surecId && p.kullaniciId == ks.kullaniciId select p).SingleOrDefault();
                            if (kullanicivarmi == null)
                            {
                                tblKullaniciAltSurec kas = new tblKullaniciAltSurec
                                {
                                    altSurecId = ks.surecId,
                                    kullaniciId = ks.kullaniciId
                                };
                                db.tblKullaniciAltSurecs.Add(kas);
                                db.SaveChanges();
                                result = '+';
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = '?';
            }
            return result;
        }
    }
}