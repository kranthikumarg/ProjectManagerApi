namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FSEProjectManger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentTask",
                c => new
                    {
                        Parent_ID = c.Long(nullable: false, identity: true),
                        Parent_Task = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Parent_ID);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Task_ID = c.Long(nullable: false, identity: true),
                        Parent_ID = c.Long(),
                        Project_ID = c.Long(),
                        Task = c.String(maxLength: 500),
                        Start_Date = c.DateTime(),
                        End_Date = c.DateTime(),
                        Priority = c.Short(),
                        Status = c.Boolean(),
                        User_ID = c.Long(),
                    })
                .PrimaryKey(t => t.Task_ID)
                .ForeignKey("dbo.ParentTask", t => t.Parent_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Parent_ID)
                .Index(t => t.Project_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Project_ID = c.Long(nullable: false, identity: true),
                        Project = c.String(maxLength: 500),
                        Start_Date = c.DateTime(),
                        End_Date = c.DateTime(),
                        Priority = c.Short(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Project_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_ID = c.Long(nullable: false, identity: true),
                        First_Name = c.String(maxLength: 500),
                        Last_Name = c.String(maxLength: 500),
                        Employee_ID = c.String(maxLength: 50),
                        Project_ID = c.Long(),
                    })
                .PrimaryKey(t => t.User_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.Task", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.Task", "Parent_ID", "dbo.ParentTask");
            DropIndex("dbo.Users", new[] { "Project_ID" });
            DropIndex("dbo.Task", new[] { "User_ID" });
            DropIndex("dbo.Task", new[] { "Project_ID" });
            DropIndex("dbo.Task", new[] { "Parent_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Project");
            DropTable("dbo.Task");
            DropTable("dbo.ParentTask");
        }
    }
}
