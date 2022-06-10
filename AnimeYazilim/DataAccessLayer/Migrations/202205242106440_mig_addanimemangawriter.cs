namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addanimemangawriter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animes", "WriterID", c => c.Int());
            AddColumn("dbo.Mangas", "WriterID", c => c.Int());
            CreateIndex("dbo.Animes", "WriterID");
            CreateIndex("dbo.Mangas", "WriterID");
            AddForeignKey("dbo.Animes", "WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Mangas", "WriterID", "dbo.Writers", "WriterID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mangas", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Animes", "WriterID", "dbo.Writers");
            DropIndex("dbo.Mangas", new[] { "WriterID" });
            DropIndex("dbo.Animes", new[] { "WriterID" });
            DropColumn("dbo.Mangas", "WriterID");
            DropColumn("dbo.Animes", "WriterID");
        }
    }
}
