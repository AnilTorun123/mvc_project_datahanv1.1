namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_animeepv2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimeEpisodes",
                c => new
                    {
                        AnimeEpisodeID = c.Int(nullable: false, identity: true),
                        AnimeEp = c.String(),
                        AnimeID = c.Int(nullable: false),
                        WriterID = c.Int(),
                    })
                .PrimaryKey(t => t.AnimeEpisodeID)
                .ForeignKey("dbo.Animes", t => t.AnimeID, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterID)
                .Index(t => t.AnimeID)
                .Index(t => t.WriterID);
            
            DropColumn("dbo.Animes", "AnimeEp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animes", "AnimeEp", c => c.String());
            DropForeignKey("dbo.AnimeEpisodes", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.AnimeEpisodes", "AnimeID", "dbo.Animes");
            DropIndex("dbo.AnimeEpisodes", new[] { "WriterID" });
            DropIndex("dbo.AnimeEpisodes", new[] { "AnimeID" });
            DropTable("dbo.AnimeEpisodes");
        }
    }
}
