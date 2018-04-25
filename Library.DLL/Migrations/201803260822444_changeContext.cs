namespace Library.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PublicHouseBooks", newName: "BookPublicHouses");
            DropPrimaryKey("dbo.BookPublicHouses");
            AddPrimaryKey("dbo.BookPublicHouses", new[] { "Book_BookId", "PublicHouse_PublicHouseId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BookPublicHouses");
            AddPrimaryKey("dbo.BookPublicHouses", new[] { "PublicHouse_PublicHouseId", "Book_BookId" });
            RenameTable(name: "dbo.BookPublicHouses", newName: "PublicHouseBooks");
        }
    }
}
