namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contentstatusadd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "ContentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "ContentStatus", c => c.String());
        }
    }
}
