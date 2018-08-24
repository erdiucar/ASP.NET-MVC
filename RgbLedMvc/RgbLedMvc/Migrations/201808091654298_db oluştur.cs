namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dboluştur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.Int(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                        Time = c.DateTime(nullable: false),
                        PreviousTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Leds");
        }
    }
}
