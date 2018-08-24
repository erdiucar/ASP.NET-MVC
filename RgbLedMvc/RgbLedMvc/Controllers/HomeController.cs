using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RgbLedMvc.Models;

namespace RgbLedMvc.Controllers
{
    public class HomeController : Controller
    {
        // RgbLed data modelinin nesnesini oluşturuyorum
        private RgbLedDb db = new RgbLedDb();

        // GET: Home
        public ActionResult Index()
        {
            NewViewModel model = new NewViewModel();

            // Leds tablosunun son verisini çekmeye çalışıyorum. Eğer boşsa yeni nesne oluşturuluyor
            try
            {
                model.Led = db.Leds.OrderByDescending(led => led.Id).First();
            }
            catch
            {
                model.Led = new Led();
            }

            // RgbColors tablosunun son verisini çekmeye çalışıyorum. Eğer boşsa yeni nesne oluşturuluyor
            try
            {
                model.SonRenk = db.RgbColors.OrderByDescending(color => color.Id).First();
            }
            catch
            {
                model.SonRenk = new RgbColor();
            }

            return View(model);
        }

        // Anasayfada onayla butonuna basılınca seçilen rengin değerini çekiyorum
        [HttpPost]
        public ActionResult DbEkle(string Renk)
        {
            // Arduino ile bağlantı kuruyorum. Eğer bağlantıda sorun çıkarsa catch'e atlayıp sayfayı yeniliyorum
            try
            {
                // Hex kodu int olarak renklere ayırıyorum
                string colour = Renk.TrimStart('#');
                int red = int.Parse(colour.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                int green = int.Parse(colour.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                int blue = int.Parse(colour.Substring(4, 2), NumberStyles.AllowHexSpecifier);

                // Arduino ile bağlantı kurulmaya çalışılıyor
                TcpClient TcpAc = new TcpClient("192.168.1.13", 8090);
                NetworkStream networkStream = TcpAc.GetStream();
                StreamWriter streamWriter = new StreamWriter(networkStream);
                StreamReader streamReader = new StreamReader(networkStream);

                // Arduino'ya renklerin aralarına '+' işareti koyarak mesaj gönderiyorum. En sona hex kodu ekliyorum
                streamWriter.Write(red + "+" + green + "+" + blue + "+" + Renk + "\n");
                streamWriter.Flush();

                // Arduino'dan gelen mesaja bakıyorum. Eğer renk aynı mesajı geldiyse bağlantıyı sonlandırıp sayfayı yeniliyorum
                if (streamReader.ReadToEnd() == "Renk aynı")
                {
                    networkStream.Close();

                    return RedirectToAction("Index", "Home");
                }

                // Renk aynı değilse bağlantıyı sonlandırıp veri tabanına verileri ekliyorum. Sayfayı yeniliyorum
                else
                {
                    networkStream.Close();

                    Led database1 = new Led();
                    RgbColor database2 = new RgbColor();
                    
                    database1.Color = Renk;
                    database1.IsOpen = true;
                    database1.Time = DateTime.Now;
                    database2.LastColor = Renk;

                    db.Leds.Add(database1);
                    db.RgbColors.Add(database2);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // Anasayfada kapa butonuna basılınca "Kapat" mesajını alıyorum
        [HttpPost]
        public ActionResult Kapama(string Kapa)
        {
            // Arduino ile bağlantı kuruyorum. Eğer bağlantıda sorun çıkarsa catch'e atlayıp sayfayı yeniliyorum
            try
            {
                // Arduino ile bağlantı kurulmaya çalışılıyor
                TcpClient TcpAc = new TcpClient("192.168.1.13", 8090);
                NetworkStream networkStream = TcpAc.GetStream();
                StreamWriter streamWriter = new StreamWriter(networkStream);
                StreamReader streamReader = new StreamReader(networkStream);

                // Arduino'ya "Kapat" mesajını gönderiyorum
                streamWriter.Write(Kapa + "\n");
                streamWriter.Flush();

                // Eğer led zaten kapalıysa arduino'dan "Kapalı" mesajı alıyorum. Bağlantıyı kapatıp sayfayı yeniliyorum
                if (streamReader.ReadToEnd() == "Kapalı")
                {
                    networkStream.Close();

                    return RedirectToAction("Index", "Home");
                }

                // Eğer kapalı değilse bağlantıyı sonlandırıp verileri veri tabanına ekliyorum
                else
                {
                    networkStream.Close();

                    Led database1 = new Led();
                    RgbColor database2 = new RgbColor();

                    database1.IsOpen = false;
                    database1.Time = DateTime.Now;
                    database2.LastColor = "Kapalı";

                    db.Leds.Add(database1);
                    db.RgbColors.Add(database2);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}