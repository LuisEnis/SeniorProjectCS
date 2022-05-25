namespace SeniorProjectCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreaseProductDescriptionLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 50));
        }
    }
}
