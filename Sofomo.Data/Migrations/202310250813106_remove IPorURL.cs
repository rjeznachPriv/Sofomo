namespace Sofomo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeIPorURL : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "IPorURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "IPorURL", c => c.String());
        }
    }
}
