namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbDegistir3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leds", "LastColor_Id", "dbo.RgbColors");
            DropIndex("dbo.Leds", new[] { "LastColor_Id" });
            AddColumn("dbo.Leds", "Color", c => c.String());
            AddColumn("dbo.RgbColors", "LastColor", c => c.String());
            DropColumn("dbo.Leds", "LastColor_Id");
            DropColumn("dbo.RgbColors", "ColorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RgbColors", "ColorName", c => c.String());
            AddColumn("dbo.Leds", "LastColor_Id", c => c.Int());
            DropColumn("dbo.RgbColors", "LastColor");
            DropColumn("dbo.Leds", "Color");
            CreateIndex("dbo.Leds", "LastColor_Id");
            AddForeignKey("dbo.Leds", "LastColor_Id", "dbo.RgbColors", "Id");
        }
    }
}
