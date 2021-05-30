using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DerslerController : Controller
    {
        // GET: Default
        DbMvcSchoolEntities1 db = new DbMvcSchoolEntities1();  
        public ActionResult DerslerListele()
        {
            var dersler = db.Tbl_Dersler.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult DersEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(Tbl_Dersler d)
        {
            var id = 1;
            var count = db.Tbl_Dersler.ToList().Count;
            if(count > 0 )
            {
                var last = db.Tbl_Dersler.ToList().Last();
                id = last.Ders_Id + 1;
            }
            d.Ders_Id = (byte)id;
            /*var ders = new Tbl_Dersler
            {
                Ders_Ad = d.Ders_Ad
            };*/
            db.Tbl_Dersler.Add(d);
            db.SaveChanges();
            return RedirectToAction("DerslerListele","Dersler");
        }
        public ActionResult DersSil(int id)
        {
            var Drs = db.Tbl_Dersler.Find(id);
            db.Tbl_Dersler.Remove(Drs);
            db.SaveChanges();
            return RedirectToAction("DerslerListele");
        }
        [HttpGet]
        public ActionResult DersGuncelle(int id)
        {
            var updateders = db.Tbl_Dersler.FirstOrDefault(item => item.Ders_Id == id);
            return View(updateders);
        }
        [HttpPost]
        public ActionResult DersGuncelle(Tbl_Dersler d)
        {
            var update = db.Tbl_Dersler.FirstOrDefault(item => item.Ders_Id == d.Ders_Id);
            update.Ders_Ad = d.Ders_Ad;
            db.SaveChanges();
            return RedirectToAction("DerslerListele");
        }
    }
}