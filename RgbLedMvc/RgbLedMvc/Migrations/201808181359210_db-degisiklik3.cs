namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbdegisiklik3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Leds", "PreviousTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leds", "PreviousTime", c => c.DateTime(nullable: false));
        }
    }
}
