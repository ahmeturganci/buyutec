using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataModel;

namespace Buyutec.Models.DataViewModel
{
    public class Log
    {
        public int logId { get; set; }
        public Nullable<int> kullaniciId { get; set; }//sessiondan gelecek 
        public string logBilgisi { get; set; }// işleme göre atama ? 


        public static Log MapData(tblLog r)
        {
            Log log = new Log()
            {
                logId=r.logId,
                kullaniciId=r.kullaniciId,
                logBilgisi = r.logBilgisi
            };
            return log;
        }
        public static tblLog MapData(Log r)
        {
            tblLog log = new tblLog()
            {
                logId = r.logId,
                kullaniciId = r.kullaniciId,
                logBilgisi = r.logBilgisi
            };
            return log;
        }
        public static List<Log> MapData(List<tblLog> LogList)
        {
            List<Log> liste = new List<Log>();

            foreach (var b in LogList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
        public static List<tblLog> MapData(List<Log> LogList)
        {
            List<tblLog> liste = new List<tblLog>();

            foreach (var b in LogList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
    }
}