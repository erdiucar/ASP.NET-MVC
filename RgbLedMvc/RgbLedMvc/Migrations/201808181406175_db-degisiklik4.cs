namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbdegisiklik4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leds", "PastTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leds", "PastTime");
        }
    }
}
