using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Carilers.Where(x=>x.Durum==true).ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var car = c.Carilers.Find(id);
            car.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cariler d)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            
            var car = c.Carilers.Find(d.CarilerID);
            car.CarilerAd = d.CarilerAd;
            car.CarilerSoyad = d.CarilerSoyad;
            car.CarilerSehir = d.CarilerSehir;
            car.CarilerMail = d.CarilerMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.Carilerid == id).ToList();
            var cr = c.Carilers.Where(x => x.CarilerID == id).Select(y => y.CarilerAd + " " + y.CarilerSoyad).FirstOrDefault();
            ViewBag.car = cr;
            return View(deger);
        }
    }
}