using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataModel;
namespace Buyutec.Models.DataViewModel
{
    public class AltSurec
    {
        public int altSurecId { get; set; }
        public string altSurecAdi { get; set; }
        public string baslangicTarihi { get; set; }
        public string bitisTarihi { get; set; }
        public Nullable<int> bitirmeOrani { get; set; }
        public Nullable<int> durumId { get; set; }
        public Nullable<int> oncelikId { get; set; }
        public Nullable<int> surecId { get; set; }
        public string aciklama { get; set; }

        public static AltSurec MapData(tblAltSurec altsurec)
        {
            AltSurec tblAlt = new AltSurec()
            {
                surecId = altsurec.surecId,
                altSurecId = altsurec.altSurecId,
                altSurecAdi = altsurec.altSurecAdi,
                aciklama = altsurec.aciklama,
                baslangicTarihi = altsurec.baslangicTarihi.ToString(),
                bitisTarihi = altsurec.bitisTarihi.ToString(),
                bitirmeOrani = altsurec.bitirmeOrani,
                durumId = altsurec.durumId,
                oncelikId = altsurec.oncelikId
            };
            return tblAlt;
        }

        public static tblAltSurec MapData(AltSurec altsurec)
        {
            tblAltSurec tblAlt = new tblAltSurec()
            {
                surecId = altsurec.surecId,
                altSurecId = altsurec.altSurecId,
                altSurecAdi = altsurec.altSurecAdi,
                aciklama = altsurec.aciklama,
                baslangicTarihi = Convert.ToDateTime(altsurec.baslangicTarihi),
                bitisTarihi = Convert.ToDateTime(altsurec.bitisTarihi),
                bitirmeOrani = altsurec.bitirmeOrani,
                durumId = altsurec.durumId,
                oncelikId = altsurec.oncelikId
            };
            return tblAlt;
        }
        public static List<AltSurec> MapData(List<tblAltSurec> AltSurecList)
        {
            List<AltSurec> liste = new List<AltSurec>();

            foreach (var b in AltSurecList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
        public static List<tblAltSurec> MapData(List<AltSurec> AltSurecList)
        {
            List<tblAltSurec> liste = new List<tblAltSurec>();

            foreach (var b in AltSurecList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
    }
}