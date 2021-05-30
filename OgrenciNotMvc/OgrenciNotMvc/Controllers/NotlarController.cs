using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;
namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        DbMvcSchoolEntities1 db = new DbMvcSchoolEntities1();
        // GET: Notlar
        public ActionResult NotListele()
        {
            var Notlar = db.Tbl_Notlar.ToList();
            return View(Notlar);
        }
        [HttpGet]
        public ActionResult SinavEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotEkle(Tbl_Notlar n)
        {
            db.Tbl_Notlar.Add(n);
            db.SaveChanges();
            return RedirectToAction("NotlarListele");
        }
        public ActionResult NotGuncelle(int id)
        {
            var notlar = db.Tbl_Notlar.Find(id);
            return View(notlar);
        }
        [HttpPost]
        public ActionResult NotGuncelle(Tbl_Notlar not,Islemler islemler)
        {
            if(islemler.Islem == "Hesapla")
            {
                decimal ort = (decimal)((not.Sınav1 + not.Sınav2 + not.Proje) / 3);
                not.Ortalama = ort;
                return View(not);
            }
            if (islemler.Islem == "NotGuncelle")
            {
                var update = db.Tbl_Notlar.Find(not.Not_Id);
                update.Ders_Id = not.Ders_Id;
                update.Ogrenci_Id = not.Ogrenci_Id;
                update.Sınav1 = not.Sınav1;
                update.Sınav2 = not.Sınav2;
                update.Proje = not.Proje;
                update.Ortalama = not.Ortalama;
                update.Durum = not.Durum;
                db.SaveChanges();
                return RedirectToAction("NotListele");
            }
            return RedirectToAction("NotListele");
        }
    }
}