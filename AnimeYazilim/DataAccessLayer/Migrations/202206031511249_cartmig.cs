namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        WriterID = c.String(),
                    })
                .PrimaryKey(t => t.CartID);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemID = c.Int(nullable: false, identity: true),
                        AnimeID = c.Int(nullable: false),
                        CartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemID)
                .ForeignKey("dbo.Animes", t => t.AnimeID, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.CartID, cascadeDelete: true)
                .Index(t => t.AnimeID)
                .Index(t => t.CartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "CartID", "dbo.Carts");
            DropForeignKey("dbo.CartItems", "AnimeID", "dbo.Animes");
            DropIndex("dbo.CartItems", new[] { "CartID" });
            DropIndex("dbo.CartItems", new[] { "AnimeID" });
            DropTable("dbo.CartItems");
            DropTable("dbo.Carts");
        }
    }
}
