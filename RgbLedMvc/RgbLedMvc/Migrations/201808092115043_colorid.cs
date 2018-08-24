namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colorid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leds", "ColorId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leds", "ColorId");
        }
    }
}
