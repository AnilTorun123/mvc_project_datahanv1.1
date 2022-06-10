namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mangamig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MangaEpisodes",
                c => new
                    {
                        MangaEpisodeID = c.Int(nullable: false, identity: true),
                        MangaEpNum = c.String(),
                        MangaEpPage1 = c.String(),
                        MangaEpPage2 = c.String(),
                        MangaEpPage3 = c.String(),
                        MangaEpPage4 = c.String(),
                        MangaEpPage5 = c.String(),
                        MangaEpPage6 = c.String(),
                        MangaEpPage7 = c.String(),
                        MangaEpPage8 = c.String(),
                        MangaEpPage9 = c.String(),
                        MangaEpPage10 = c.String(),
                        MangaEpPage11 = c.String(),
                        MangaEpPage12 = c.String(),
                        MangaEpPage13 = c.String(),
                        MangaEpPage14 = c.String(),
                        MangaEpPage15 = c.String(),
                        MangaEpPage16 = c.String(),
                        MangaEpPage17 = c.String(),
                        MangaEpPage18 = c.String(),
                        MangaEpPage19 = c.String(),
                        MangaEpPage20 = c.String(),
                        MangaID = c.Int(nullable: false),
                        WriterID = c.Int(),
                    })
                .PrimaryKey(t => t.MangaEpisodeID)
                .ForeignKey("dbo.Mangas", t => t.MangaID, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterID)
                .Index(t => t.MangaID)
                .Index(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MangaEpisodes", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.MangaEpisodes", "MangaID", "dbo.Mangas");
            DropIndex("dbo.MangaEpisodes", new[] { "WriterID" });
            DropIndex("dbo.MangaEpisodes", new[] { "MangaID" });
            DropTable("dbo.MangaEpisodes");
        }
    }
}
