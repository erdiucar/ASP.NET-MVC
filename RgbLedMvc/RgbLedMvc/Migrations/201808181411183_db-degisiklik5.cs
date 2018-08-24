namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbdegisiklik5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leds", "LastColor", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leds", "LastColor");
        }
    }
}
