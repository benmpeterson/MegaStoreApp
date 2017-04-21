namespace MegaStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class albumartuniqueid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumID = c.Int(nullable: false),
                        Artist = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Genre = c.String(maxLength: 50),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        AlbumArtLocation = c.String(),
                        GenreCategory_GenreID = c.Int(),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Genre", t => t.GenreCategory_GenreID)
                .Index(t => t.GenreCategory_GenreID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstMidName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        TotalSold = c.Decimal(nullable: false, storeType: "money"),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchasesID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.PurchasesID)
                .ForeignKey("dbo.Album", t => t.AlbumID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.AlbumID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(nullable: false),
                        PurchaseID = c.Int(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstMidName = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.EmployeeAlbum",
                c => new
                    {
                        Employee_EmployeeID = c.Int(nullable: false),
                        Album_AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeID, t.Album_AlbumID })
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Album", t => t.Album_AlbumID, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.Album_AlbumID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Purchases", "AlbumID", "dbo.Album");
            DropForeignKey("dbo.Album", "GenreCategory_GenreID", "dbo.Genre");
            DropForeignKey("dbo.EmployeeAlbum", "Album_AlbumID", "dbo.Album");
            DropForeignKey("dbo.EmployeeAlbum", "Employee_EmployeeID", "dbo.Employee");
            DropIndex("dbo.EmployeeAlbum", new[] { "Album_AlbumID" });
            DropIndex("dbo.EmployeeAlbum", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.Purchases", new[] { "CustomerID" });
            DropIndex("dbo.Purchases", new[] { "AlbumID" });
            DropIndex("dbo.Album", new[] { "GenreCategory_GenreID" });
            DropTable("dbo.EmployeeAlbum");
            DropTable("dbo.Customer");
            DropTable("dbo.Purchases");
            DropTable("dbo.Genre");
            DropTable("dbo.Employee");
            DropTable("dbo.Album");
        }
    }
}
