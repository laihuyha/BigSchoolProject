namespace BigSchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        Namw = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LectureID = c.Int(nullable: false),
                        Place = c.String(nullable: false, maxLength: 255),
                        datetime = c.DateTime(nullable: false),
                        CategoryId = c.Byte(nullable: false),
                        Lecture_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Lecture_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Lecture_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Lecture_Id" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
