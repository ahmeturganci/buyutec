using Buyutec.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buyutec.Models.DataViewModel
{
    public class Oncelik
    {
        public int oncelikId { get; set; }
        public string oncelikAdi { get; set; }

        public static Oncelik MapData(tblOncelik r)
        {
            Oncelik oncelik = new Oncelik()
            {
                oncelikId = r.oncelikId,
                oncelikAdi = r.oncelikAdi
            };
            return oncelik;
        }
        public static tblOncelik MapData(Oncelik r)
        {
            tblOncelik oncelik = new tblOncelik()
            {
                oncelikId = r.oncelikId,
                oncelikAdi = r.oncelikAdi
            };
            return oncelik;
        }
        public static List<Oncelik> MapData(List<tblOncelik> OncelikList)
        {
            List<Oncelik> liste = new List<Oncelik>();

            foreach (var b in OncelikList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
        public static List<tblOncelik> MapData(List<Oncelik> OncelikList)
        {
            List<tblOncelik> liste = new List<tblOncelik>();

            foreach (var b in OncelikList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
    }
}