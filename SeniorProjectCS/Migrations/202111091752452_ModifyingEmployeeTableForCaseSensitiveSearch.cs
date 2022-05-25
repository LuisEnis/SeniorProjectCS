namespace SeniorProjectCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingEmployeeTableForCaseSensitiveSearch : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Employees ALTER COLUMN Username VARCHAR(50) COLLATE Latin1_General_CS_AS");
            Sql("ALTER TABLE Employees ALTER COLUMN Password VARCHAR(50) COLLATE Latin1_General_CS_AS");
        }
        
        public override void Down()
        {
        }
    }
}
