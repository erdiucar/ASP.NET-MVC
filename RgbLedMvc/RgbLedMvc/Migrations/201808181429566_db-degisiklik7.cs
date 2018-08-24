namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbdegisiklik7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Leds", "PastTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leds", "PastTime", c => c.Int(nullable: false));
        }
    }
}
