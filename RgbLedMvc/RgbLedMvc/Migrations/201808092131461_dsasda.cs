namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsasda : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Leds", "ColorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leds", "ColorId", c => c.Byte(nullable: false));
        }
    }
}
