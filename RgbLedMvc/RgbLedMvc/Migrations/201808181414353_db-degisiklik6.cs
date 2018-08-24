namespace RgbLedMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbdegisiklik6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leds", "LastColor", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leds", "LastColor", c => c.String(nullable: false));
        }
    }
}
