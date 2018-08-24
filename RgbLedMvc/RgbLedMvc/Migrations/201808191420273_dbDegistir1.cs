namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbDegistir1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RgbColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Leds", "LastColor_Id", c => c.Int());
            CreateIndex("dbo.Leds", "LastColor_Id");
            AddForeignKey("dbo.Leds", "LastColor_Id", "dbo.RgbColors", "Id");
            DropColumn("dbo.Leds", "LastColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leds", "LastColor", c => c.String());
            DropForeignKey("dbo.Leds", "LastColor_Id", "dbo.RgbColors");
            DropIndex("dbo.Leds", new[] { "LastColor_Id" });
            DropColumn("dbo.Leds", "LastColor_Id");
            DropTable("dbo.RgbColors");
        }
    }
}
