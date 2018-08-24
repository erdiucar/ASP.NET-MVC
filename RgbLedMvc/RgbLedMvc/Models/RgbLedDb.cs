using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace RgbLedMvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RgbLedDb : DbContext
    {
        // Your context has been configured to use a 'RgbLedDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RgbLedMvc.Models.RgbLedDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RgbLedDb' 
        // connection string in the application configuration file.
        public RgbLedDb()
            : base("name=RgbLedDb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Led> Leds { get; set; }
        public virtual DbSet<RgbColor> RgbColors { get; set; }
    }

    // Entity framework ile database oluþturduðum için Led ve RgbColor isimli 2 tablo oluþturdum
    public class Led
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public bool IsOpen { get; set; }
        public DateTime Time { get; set; }
    }

    public class RgbColor
    {
        public int Id { get; set; }
        public string LastColor { get; set; }
    }
}