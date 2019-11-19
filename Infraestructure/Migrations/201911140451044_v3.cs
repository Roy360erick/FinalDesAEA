namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesInvoces", "discount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesInvoces", "discount");
        }
    }
}
