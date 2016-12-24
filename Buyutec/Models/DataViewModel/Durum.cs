using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataModel;
namespace Buyutec.Models.DataViewModel
{
    public class Durum
    {
        public int durumId { get; set; }
        public string durumAdi { get; set; }
        public static Durum MapData(tblDurum d)
        {
            Durum durum = new Durum()
            {
                durumAdi = d.durumAdi
            };
            return durum;
        }
        public static tblDurum MapData(Durum d)
        {
            tblDurum durum = new tblDurum()
            {
                durumAdi = d.durumAdi
            };
            return durum;
        }
        public static List<Durum> MapData(List<tblDurum> DurumList)
        {
            List<Durum> liste = new List<Durum>();

            foreach (var b in DurumList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
        public static List<tblDurum> MapData(List<Durum> DurumListe)
        {
            List<tblDurum> liste = new List<tblDurum>();

            foreach (var b in DurumListe)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
    }
}