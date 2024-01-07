namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingModelFreeseedDistribution : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FreeSeedsDistributions", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FreeSeedsDistributions", "Location", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
