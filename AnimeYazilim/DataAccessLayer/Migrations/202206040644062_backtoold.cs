namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backtoold : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "AnimeID", "dbo.Animes");
            DropForeignKey("dbo.CartItems", "CartID", "dbo.Carts");
            DropIndex("dbo.CartItems", new[] { "AnimeID" });
            DropIndex("dbo.CartItems", new[] { "CartID" });
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemID = c.Int(nullable: false, identity: true),
                        AnimeID = c.Int(nullable: false),
                        CartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        WriterID = c.String(),
                    })
                .PrimaryKey(t => t.CartID);
            
            CreateIndex("dbo.CartItems", "CartID");
            CreateIndex("dbo.CartItems", "AnimeID");
            AddForeignKey("dbo.CartItems", "CartID", "dbo.Carts", "CartID", cascadeDelete: true);
            AddForeignKey("dbo.CartItems", "AnimeID", "dbo.Animes", "AnimeID", cascadeDelete: true);
        }
    }
}
