namespace MVCTreeview.Migrations.EmployeeMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        ManagerID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Employees", t => t.ManagerID)
                .Index(t => t.ManagerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ManagerID", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "ManagerID" });
            DropTable("dbo.Employees");
        }
    }
}
