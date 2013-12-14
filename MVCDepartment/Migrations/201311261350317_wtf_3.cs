namespace MVCDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf_3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Specialties", "GlobalId", c => c.String(nullable: false));
            AlterColumn("dbo.Specialties", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Specialties", "Name", c => c.String());
            AlterColumn("dbo.Specialties", "GlobalId", c => c.String());
        }
    }
}
