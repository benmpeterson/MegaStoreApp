namespace MegaStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "PurchaseID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "PurchaseID");
        }
    }
}
