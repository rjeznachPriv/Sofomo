namespace Sofomo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "IPorURL", c => c.String());
            AddColumn("dbo.Locations", "City", c => c.String());
            AddColumn("dbo.Locations", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "Country");
            DropColumn("dbo.Locations", "City");
            DropColumn("dbo.Locations", "IPorURL");
        }
    }
}
