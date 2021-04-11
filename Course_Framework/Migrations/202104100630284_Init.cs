namespace Course_Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BS_Course",
                c => new
                    {
                        CourseNo = c.Int(nullable: false, identity: true),
                        CourseID = c.String(nullable: false, maxLength: 4),
                        Name = c.String(nullable: false, maxLength: 20),
                        Credits = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 20),
                        TeacherName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CourseNo);
            
            CreateTable(
                "dbo.BS_Enrollment",
                c => new
                    {
                        EnrollmentNo = c.Int(nullable: false, identity: true),
                        StudentNo = c.Int(nullable: false),
                        CourseNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentNo)
                .ForeignKey("dbo.BS_Course", t => t.CourseNo, cascadeDelete: true)
                .ForeignKey("dbo.SE_Student", t => t.StudentNo, cascadeDelete: true)
                .Index(t => t.StudentNo)
                .Index(t => t.CourseNo);
            
            CreateTable(
                "dbo.SE_Student",
                c => new
                    {
                        StudentNo = c.Int(nullable: false, identity: true),
                        StudentID = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 20),
                        Birth = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StudentNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BS_Enrollment", "StudentNo", "dbo.SE_Student");
            DropForeignKey("dbo.BS_Enrollment", "CourseNo", "dbo.BS_Course");
            DropIndex("dbo.BS_Enrollment", new[] { "CourseNo" });
            DropIndex("dbo.BS_Enrollment", new[] { "StudentNo" });
            DropTable("dbo.SE_Student");
            DropTable("dbo.BS_Enrollment");
            DropTable("dbo.BS_Course");
        }
    }
}
