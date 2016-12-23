using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyutec.Models;
using Buyutec.IslerKatmani;
namespace Buyutec.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            if (Session["kulMail"] == null)
                Response.Redirect("/Home/Index");
            return View();
        }
        public ActionResult ProjeOlustur()
        {
            return View();
        }
        

    }
}