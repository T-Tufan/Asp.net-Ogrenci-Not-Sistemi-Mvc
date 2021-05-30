using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
        DbMvcSchoolEntities1 db = new DbMvcSchoolEntities1();
        // GET: Kulupler
        public ActionResult KuluplerListele()
        {
            var kulupler = db.Tbl_Kulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult KulupEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KulupEkle(Tbl_Kulupler k)
        {
            db.Tbl_Kulupler.Add(k);
            db.SaveChanges();
            return RedirectToAction("KuluplerListele", "Kulupler");
        }
        public ActionResult KulupSil(int id)
        {
            var Klp = db.Tbl_Kulupler.Find(id);
            db.Tbl_Kulupler.Remove(Klp);
            db.SaveChanges();
            return RedirectToAction("KuluplerListele");
        }
        public ActionResult KulupGuncelle(int id)
        {
            ViewBag.Id = id;
            var kulup = db.Tbl_Kulupler.Find(id);
            return View(kulup);
        }
        [HttpPost]
        public ActionResult KulupGuncelle(Tbl_Kulupler klp)
        {
            var updateKulup = db.Tbl_Kulupler.Find(klp.Kulup_Id);
            updateKulup.Kulup_Ad = klp.Kulup_Ad;
            updateKulup.Kulup_Id = klp.Kulup_Id;
            updateKulup.Kulup_Kontenjan = klp.Kulup_Kontenjan;
            /*updateKulup = new Tbl_Kulupler
            {
                Kulup_Id = klp.Kulup_Id,
                Kulup_Ad = klp.Kulup_Ad,
                Kulup_Kontenjan = klp.Kulup_Kontenjan
            };*/
            db.SaveChanges();
            return RedirectToAction("KuluplerListele");
        }
    }
}