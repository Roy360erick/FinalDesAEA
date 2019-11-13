namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.SalesInvoces",
                c => new
                    {
                        SalesInvoceID = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SellerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesInvoceID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.SellerID);
            
            CreateTable(
                "dbo.SalesInvoceDetails",
                c => new
                    {
                        SalesInvoceDetailID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Single(nullable: false),
                        SalesInvoceID = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.SalesInvoceDetailID)
                .ForeignKey("dbo.SalesInvoces", t => t.SalesInvoceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.SalesInvoceID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SellerID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesInvoceDetails", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.SalesInvoces", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.SalesInvoceDetails", "SalesInvoceID", "dbo.SalesInvoces");
            DropForeignKey("dbo.SalesInvoces", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SalesInvoceDetails", new[] { "Product_ProductID" });
            DropIndex("dbo.SalesInvoceDetails", new[] { "SalesInvoceID" });
            DropIndex("dbo.SalesInvoces", new[] { "SellerID" });
            DropIndex("dbo.SalesInvoces", new[] { "CustomerID" });
            DropTable("dbo.Products");
            DropTable("dbo.Sellers");
            DropTable("dbo.SalesInvoceDetails");
            DropTable("dbo.SalesInvoces");
            DropTable("dbo.Customers");
        }
    }
}
