namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class color : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Leds", "Color_Id");
            AddForeignKey("dbo.Leds", "Color_Id", "dbo.Colors", "Id");
            DropColumn("dbo.Leds", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leds", "Color", c => c.Int(nullable: false));
            DropForeignKey("dbo.Leds", "Color_Id", "dbo.Colors");
            DropIndex("dbo.Leds", new[] { "Color_Id" });
            DropColumn("dbo.Leds", "Color_Id");
            DropTable("dbo.Colors");
        }
    }
}
