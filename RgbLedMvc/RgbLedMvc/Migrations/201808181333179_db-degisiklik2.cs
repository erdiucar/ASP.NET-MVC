namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbdegisiklik2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leds", "LastColor_Id", "dbo.LastColors");
            DropIndex("dbo.Leds", new[] { "LastColor_Id" });
            DropColumn("dbo.Leds", "LastColor_Id");
            DropTable("dbo.LastColors");
        }
        
        public override void Down()
        {
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
        }
    }
}
