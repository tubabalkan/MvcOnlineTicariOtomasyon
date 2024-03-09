using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Faturalars.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);

            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var ftr = c.Faturalars.Find(f.FaturaID);
            ftr.FaturaSeriNo = f.FaturaSeriNo;
            ftr.FaturaSıraNo = f.FaturaSıraNo;
            ftr.VergiDairesi = f.VergiDairesi;
            ftr.Tarih = f.Tarih;
            ftr.Saat = f.Saat;
            ftr.TeslimEden = f.TeslimEden;
            ftr.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}