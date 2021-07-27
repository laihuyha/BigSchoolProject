namespace BigSchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsCanceledColumntoCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "isCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "isCanceled");
        }
    }
}
