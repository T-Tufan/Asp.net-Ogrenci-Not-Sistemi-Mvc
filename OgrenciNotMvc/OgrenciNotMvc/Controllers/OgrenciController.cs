using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        DbMvcSchoolEntities1 db = new DbMvcSchoolEntities1();
        // GET: Ogrenci
        public ActionResult OgrenciListele()
        {
            var ogrenciler = db.Tbl_Ogrenci.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            /*
            List<SelectListItem> lectures = new List<SelectListItem>();

            lectures.Add(new SelectListItem { Text = "Matematik", Value = "0" });

            lectures.Add(new SelectListItem { Text = "Fen", Value = "1" });

            lectures.Add(new SelectListItem { Text = "Tarih", Value = "2" });

            lectures.Add(new SelectListItem { Text = "Beden Eğitimi", Value = "3" });

            ViewBag.Lectures = lectures;
            */
            //LinQ sorguda ilk parametre verini çekileceği yer , 
            List<SelectListItem> degerler = new List<SelectListItem>();
            degerler = KulupListIslemleri(degerler, db);
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(Tbl_Ogrenci o)
        {
            var id = 1;
            var count = db.Tbl_Ogrenci.ToList().Count;
            if (count > 0)
            {
                var last_ogr_id = db.Tbl_Ogrenci.ToList().Last();
                id = last_ogr_id.Ogrenci_Id + 1;
            }
            var klp = db.Tbl_Kulupler.Where(m => m.Kulup_Id == o.Tbl_Kulupler.Kulup_Id).FirstOrDefault();
            o.Tbl_Kulupler = klp;
            o.Ogrenci_Id = (byte)id;
            o.Ogrenci_Cinsiyet = OgrenciCinsiyet(o);
            db.Tbl_Ogrenci.Add(o);
            db.SaveChanges();
            return RedirectToAction("OgrenciListele", "Ogrenci");
        }

        public ActionResult OgrenciSil(int id)
        {
            var ogr = db.Tbl_Ogrenci.Find(id);
            db.Tbl_Ogrenci.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("OgrenciListele");
        }
        public ActionResult OgrenciGuncelle(int id)
        {
            List<SelectListItem> kulupDropDownList = new List<SelectListItem>();
            List<SelectListItem> cinsiyetDropdownList = new List<SelectListItem>()
            {
                new SelectListItem{Text = "Kadın", Value = 0.ToString()},
                new SelectListItem{Text = "Erkek", Value = 1.ToString()},
            };

            kulupDropDownList = KulupListIslemleri(kulupDropDownList, db);
            ViewBag.dgr = kulupDropDownList;
            ViewBag.cnsyt = cinsiyetDropdownList;
            var updateogrenci = db.Tbl_Ogrenci.Find(id);
            return View(updateogrenci);
        }
        [HttpPost]
        public ActionResult OgrenciGuncelle(Tbl_Ogrenci ogr)
        {
            var update = db.Tbl_Ogrenci.Find(ogr.Ogrenci_Id);
            var ogrklp = db.Tbl_Kulupler.Where(m => m.Kulup_Id == ogr.Tbl_Kulupler.Kulup_Id).FirstOrDefault();
            update.Ogrenci_Id = ogr.Ogrenci_Id;
            update.Ogrenci_Ad = ogr.Ogrenci_Ad;
            update.Ogrenci_Soyad = ogr.Ogrenci_Soyad;
            update.Ogrenci_Kulup_Id = ogrklp.Kulup_Id;
            update.Ogrenci_Cinsiyet = OgrenciCinsiyet(ogr);
            update.Ogrenci_Fotograf = ogr.Ogrenci_Fotograf;
            db.SaveChanges();
            return RedirectToAction("OgrenciListele");
        }
        public string OgrenciCinsiyet(Tbl_Ogrenci o)
        {
            switch (o.Ogrenci_Cinsiyet)
            {
                case "0":
                    return "Kadın";
                case "1":
                    return "Erkek";
                default:
                    return "Bilgi Yok";
            }
        }
        public List<SelectListItem> KulupListIslemleri(List<SelectListItem> deger,DbMvcSchoolEntities1 db)
        {
            deger = (from i in db.Tbl_Kulupler.ToList()
                     select new SelectListItem
                     {
                         Text = i.Kulup_Ad,
                         Value = i.Kulup_Id.ToString()
                     }).ToList();
            return deger;
        }
    }
}