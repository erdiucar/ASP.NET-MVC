namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbdegisiklik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leds", "Color_Id", "dbo.Colors");
            DropIndex("dbo.Leds", new[] { "Color_Id" });
            CreateTable(
                "dbo.LastColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Leds", "LastColor_Id", c => c.Int());
            CreateIndex("dbo.Leds", "LastColor_Id");
            AddForeignKey("dbo.Leds", "LastColor_Id", "dbo.LastColors", "Id");
            DropColumn("dbo.Leds", "Color_Id");
            DropTable("dbo.Colors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Leds", "Color_Id", c => c.Int());
            DropForeignKey("dbo.Leds", "LastColor_Id", "dbo.LastColors");
            DropIndex("dbo.Leds", new[] { "LastColor_Id" });
            DropColumn("dbo.Leds", "LastColor_Id");
            DropTable("dbo.LastColors");
            CreateIndex("dbo.Leds", "Color_Id");
            AddForeignKey("dbo.Leds", "Color_Id", "dbo.Colors", "Id");
        }
    }
}
