using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class NotHesaplamaController : Controller
    {
        // GET: NotHesaplama
        public ActionResult NotHesapla(int sinav1 = 0 ,int sinav2 = 0 ,int proje = 0)
        {
            double ortalama = (double)(sinav1 * 0.50 + sinav2 * 0.35 + proje * 0.15);
            ViewBag.Ort = ortalama;
            return View();
        }
    }
}