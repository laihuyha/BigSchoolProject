namespace BigSchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InittialMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            AddColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Courses", "CategoryID");
            DropColumn("dbo.Categories", "Namw");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Namw", c => c.String(nullable: false, maxLength: 255));
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropColumn("dbo.Categories", "Name");
            CreateIndex("dbo.Courses", "CategoryId");
        }
    }
}
