namespace CourseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_users_and_permissions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailiabilityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Institution_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.Institution_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Institution_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Permissions", "Institution_Id", "dbo.Institutions");
            DropIndex("dbo.Permissions", new[] { "User_Id" });
            DropIndex("dbo.Permissions", new[] { "Institution_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Permissions");
            DropTable("dbo.Institutions");
            DropTable("dbo.AvailiabilityTypes");
        }
    }
}
