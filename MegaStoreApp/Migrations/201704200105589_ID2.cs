namespace MegaStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ID2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "AlbumID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "AlbumID");
        }
    }
}
