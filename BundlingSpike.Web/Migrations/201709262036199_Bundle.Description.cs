namespace BundlingSpike.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BundleDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bundles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bundles", "Description");
        }
    }
}
