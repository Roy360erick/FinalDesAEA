namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesInvoceDetails", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.SalesInvoceDetails", new[] { "Product_ProductID" });
            RenameColumn(table: "dbo.SalesInvoceDetails", name: "Product_ProductID", newName: "ProductID");
            AlterColumn("dbo.SalesInvoceDetails", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesInvoceDetails", "ProductID");
            AddForeignKey("dbo.SalesInvoceDetails", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesInvoceDetails", "ProductID", "dbo.Products");
            DropIndex("dbo.SalesInvoceDetails", new[] { "ProductID" });
            AlterColumn("dbo.SalesInvoceDetails", "ProductID", c => c.Int());
            RenameColumn(table: "dbo.SalesInvoceDetails", name: "ProductID", newName: "Product_ProductID");
            CreateIndex("dbo.SalesInvoceDetails", "Product_ProductID");
            AddForeignKey("dbo.SalesInvoceDetails", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
