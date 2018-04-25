namespace Library.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorName = c.String(),
                        YearOfPublishing = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.PublicHouses",
                c => new
                    {
                        PublicHouseId = c.Int(nullable: false, identity: true),
                        PublicHouseName = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.PublicHouseId);
            
            CreateTable(
                "dbo.Brochures",
                c => new
                    {
                        BrochureId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeOfCover = c.String(),
                        NumberOfPages = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrochureId);
            
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        MagazineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorName = c.String(),
                        YearOfPublishing = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MagazineId);
            
            CreateTable(
                "dbo.PublicHouseBooks",
                c => new
                    {
                        PublicHouse_PublicHouseId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PublicHouse_PublicHouseId, t.Book_BookId })
                .ForeignKey("dbo.PublicHouses", t => t.PublicHouse_PublicHouseId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.PublicHouse_PublicHouseId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicHouseBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.PublicHouseBooks", "PublicHouse_PublicHouseId", "dbo.PublicHouses");
            DropIndex("dbo.PublicHouseBooks", new[] { "Book_BookId" });
            DropIndex("dbo.PublicHouseBooks", new[] { "PublicHouse_PublicHouseId" });
            DropTable("dbo.PublicHouseBooks");
            DropTable("dbo.Magazines");
            DropTable("dbo.Brochures");
            DropTable("dbo.PublicHouses");
            DropTable("dbo.Books");
        }
    }
}
