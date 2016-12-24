using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buyutec.Models.DataModel;

namespace Buyutec.Models.DataViewModel
{
    public class Rol
    {
        public int rolId { get; set; }
        public string rolAdi { get; set; }

        public static Rol MapData(tblRol r)
        {
            Rol rol = new Rol()
            {
                rolAdi = r.rolAdi
            };
            return rol;
        }
        public static tblRol MapData(Rol r)
        {
            tblRol rol = new tblRol()
            {
                rolAdi = r.rolAdi
            };
            return rol;
        }
        public static List<Rol> MapData(List<tblRol> RolList)
        {
            List<Rol> liste = new List<Rol>();

            foreach (var b in RolList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
        public static List<tblRol> MapData(List<Rol> RolList)
        {
            List<tblRol> liste = new List<tblRol>();

            foreach (var b in RolList)
            {
                liste.Add(MapData(b));
            }
            return liste;
        }
    }
}