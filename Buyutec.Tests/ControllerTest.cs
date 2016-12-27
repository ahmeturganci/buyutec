using Buyutec.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace Buyutec.Tests
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var home = new HomeController();
            ViewResult res = home.Index() as ViewResult;
            Assert.IsNotNull(res);
        }
        void GirisKontrol(string kulMail, string kulSifre)
        {
            var giris = new Controllers.HomeController();
            JsonResult res = giris.Giris(kulMail, kulSifre) as JsonResult;
            Assert.AreEqual("-", res.Data.ToString());
        }
        [TestMethod]
        public void Giris()
        {
            GirisKontrol("qweqq ", "wqeqwasd");
        }
        [TestMethod]
        public void GirisBos()
        {
            GirisKontrol("", "");
        }
        [TestMethod]
        public void ProjeIndex()
        {
            var proje = new ProjeController();
            ViewResult res = proje.Index() as ViewResult;
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void ProjeDetay()
        {
            var proje = new ProjeController();
            ViewResult res = proje.ProjeDetay(1) as ViewResult;
            Assert.IsNotNull(res);
        }
    }
}
