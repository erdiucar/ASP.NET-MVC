using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RgbLedMvc.Models;

namespace RgbLedMvc.Controllers
{
    public class VeriTabaniController : Controller
    {
        private RgbLedDb db = new RgbLedDb();

        // GET: VeriTabani
        public ActionResult Index()
        {
            // Veri tabanındaki tüm verileri listeleyerek veri tabanı ekranına gönderiyorum
            return View(db.Leds.ToList());
        }

        // Veri tabanını temizle butonuna basılınca Leds tablosundaki tüm verileri siliyorum
        [HttpPost]
        public ActionResult DbSil()
        {
            var databaseLeds = db.Leds;
            db.Leds.RemoveRange(databaseLeds);
            db.SaveChanges();

            return RedirectToAction("Index", "VeriTabani");
        }
    }
}