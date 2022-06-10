namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_animeepnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnimeEpisodes", "AnimeEpNum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnimeEpisodes", "AnimeEpNum");
        }
    }
}
