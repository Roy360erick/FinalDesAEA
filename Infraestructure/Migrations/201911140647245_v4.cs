namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesInvoces", "Number", c => c.String());
            AddColumn("dbo.SalesInvoces", "Payed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesInvoces", "Payed");
            DropColumn("dbo.SalesInvoces", "Number");
        }
    }
}
