namespace MegaStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        Album_AlbumID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Album", t => t.Album_AlbumID)
                .Index(t => t.Album_AlbumID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchasesID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.PurchasesID)
                .ForeignKey("dbo.Album", t => t.AlbumID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.AlbumID)
                .Index(t => t.CustomerID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstMidName = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Album", "GenreCategory_GenreID", "dbo.Genre");
            DropForeignKey("dbo.Employee", "Album_AlbumID", "dbo.Album");
            DropForeignKey("dbo.Purchases", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Purchases", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Purchases", "AlbumID", "dbo.Album");
            DropIndex("dbo.Purchases", new[] { "EmployeeID" });
            DropIndex("dbo.Purchases", new[] { "CustomerID" });
            DropIndex("dbo.Purchases", new[] { "AlbumID" });
            DropIndex("dbo.Employee", new[] { "Album_AlbumID" });
            DropIndex("dbo.Album", new[] { "GenreCategory_GenreID" });
            DropTable("dbo.Genre");
            DropTable("dbo.Customer");
            DropTable("dbo.Purchases");
            DropTable("dbo.Employee");
            DropTable("dbo.Album");
        }
    }
}
