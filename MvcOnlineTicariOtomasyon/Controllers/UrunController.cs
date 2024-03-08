using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x=>x.Durum==true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urn = c.Uruns.Find(id);
            urn.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunID);
            urn.UrunAd = u.UrunAd;
            urn.AlisFiyati = u.AlisFiyati;
            urn.SatisFiyati = u.SatisFiyati;
            urn.Durum = u.Durum;
            urn.KategoriId = u.KategoriId;
            urn.Stok = u.Stok;
            urn.Marka = u.Marka;
            urn.UrunGorsel = u.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}