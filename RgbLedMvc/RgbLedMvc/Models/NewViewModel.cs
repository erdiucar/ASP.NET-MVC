using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace RgbLedMvc.Models
{
    // Anasayfaya RgbColor ve Led sınıflarından bilgi gönderdiğim için yeni model oluşturdum
    public class NewViewModel
    {
        public RgbColor SonRenk { get; set; }
        public Led Led { get; set; }
    }
}