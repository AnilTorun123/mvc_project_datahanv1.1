namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class animewriterv4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.animewriter",
               c => new
               {
                   AnimeID = c.Int(nullable: true),
                   WriterID = c.Int(nullable: true),
               })
               .ForeignKey("dbo.Animes", t => t.AnimeID, cascadeDelete: true)
               .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
               .Index(t => t.AnimeID)
               .Index(t => t.WriterID);
        }
        
        public override void Down()
        {
        }
    }
}
