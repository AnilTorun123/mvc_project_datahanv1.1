namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messagerevice2_quest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
            DropColumn("dbo.Messages", "MessageRead");
        }
    }
}
