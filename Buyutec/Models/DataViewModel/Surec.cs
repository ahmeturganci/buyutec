using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataModel;

namespace Buyutec.Models.DataViewModel
{
    public class Surec
    {
        public int surecId { get; set; }
        public string surecAdi { get; set; }
        public Nullable<System.DateTime> baslangicTarihi { get; set; }
        public Nullable<System.DateTime> bitisTarihi { get; set; }
        public Nullable<int> bitirmeOrani { get; set; }
        public Nullable<int> durumId { get; set; }
        public Nullable<int> oncelikId { get; set; }
        public Nullable<int> projeId { get; set; }
        public string aciklama { get; set; }

        public static Surec MapData(tblSurec s)
        {
            Surec surec = new Surec()
            {
                surecId = s.surecId,
                surecAdi = s.surecAdi
            };
            return surec;
        }

        public static tblSurec MapData(Surec s)
        {
            tblSurec surec = new tblSurec()
            {
                surecId = s.surecId,
                surecAdi = s.surecAdi
            };
            return surec;
        }
        public static List<Surec> MapData(List<tblSurec> SurecList)
        {
            List<Surec> liste = new List<Surec>();

            foreach (var b in SurecList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
        public static List<tblSurec> MapData(List<Surec> SurecList)
        {
            List<tblSurec> liste = new List<tblSurec>();

            foreach (var b in SurecList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
    }
}