namespace SeniorProjectCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAdminToEmployee : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Employees(Username, Email, Password, Role) VALUES('Luis', 'sejdini.enis@yahoo.com', 'Luis1999', 'Admin')");
        }
        
        public override void Down()
        {
        }
    }
}
