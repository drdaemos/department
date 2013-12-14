namespace MVCDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Plan_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plans", "Id", "dbo.Specialties");
            DropIndex("dbo.Plans", new[] { "Id" });
            AddColumn("dbo.Specialties", "Plan_Id", c => c.Int());
            AlterColumn("dbo.Plans", "Id", c => c.Int(nullable: false, identity: true));
            AddForeignKey("dbo.Specialties", "Plan_Id", "dbo.Plans", "Id");
            CreateIndex("dbo.Specialties", "Plan_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Specialties", new[] { "Plan_Id" });
            DropForeignKey("dbo.Specialties", "Plan_Id", "dbo.Plans");
            AlterColumn("dbo.Plans", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Specialties", "Plan_Id");
            CreateIndex("dbo.Plans", "Id");
            AddForeignKey("dbo.Plans", "Id", "dbo.Specialties", "Id");
        }
    }
}
