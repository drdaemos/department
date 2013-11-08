namespace MVCDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Term = c.Int(nullable: false),
                        LecturesSum = c.Int(nullable: false),
                        LabsSum = c.Int(nullable: false),
                        PracticesSum = c.Int(nullable: false),
                        ExamWorksSum = c.Int(nullable: false),
                        Classroom = c.String(),
                        Discipline_Id = c.Int(),
                        UserAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.Discipline_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.ScheduleWeeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lectures = c.Int(nullable: false),
                        Labs = c.Int(nullable: false),
                        Practices = c.Int(nullable: false),
                        ExamWorks = c.Int(nullable: false),
                        WeekNumber = c.Int(nullable: false),
                        Schedule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedules", t => t.Schedule_Id)
                .Index(t => t.Schedule_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Course = c.Int(nullable: false),
                        Specialty_Id = c.Int(),
                        Schedule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialties", t => t.Specialty_Id)
                .ForeignKey("dbo.Schedules", t => t.Schedule_Id)
                .Index(t => t.Specialty_Id)
                .Index(t => t.Schedule_Id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GlobalId = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialties", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Plans", new[] { "Id" });
            DropIndex("dbo.Groups", new[] { "Schedule_Id" });
            DropIndex("dbo.Groups", new[] { "Specialty_Id" });
            DropIndex("dbo.ScheduleWeeks", new[] { "Schedule_Id" });
            DropIndex("dbo.Schedules", new[] { "UserAccount_Id" });
            DropIndex("dbo.Schedules", new[] { "Discipline_Id" });
            DropForeignKey("dbo.Plans", "Id", "dbo.Specialties");
            DropForeignKey("dbo.Groups", "Schedule_Id", "dbo.Schedules");
            DropForeignKey("dbo.Groups", "Specialty_Id", "dbo.Specialties");
            DropForeignKey("dbo.ScheduleWeeks", "Schedule_Id", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.Schedules", "Discipline_Id", "dbo.Disciplines");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Plans");
            DropTable("dbo.Specialties");
            DropTable("dbo.Groups");
            DropTable("dbo.ScheduleWeeks");
            DropTable("dbo.Schedules");
            DropTable("dbo.UserAccounts");
        }
    }
}
