namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contentstatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentStatus", c => c.String());
            AlterColumn("dbo.Contents", "ContentText", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "ContentText", c => c.String(maxLength: 1000));
            DropColumn("dbo.Contents", "ContentStatus");
        }
    }
}
