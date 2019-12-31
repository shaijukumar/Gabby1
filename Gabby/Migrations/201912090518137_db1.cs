namespace Gabby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AluMembers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AluMembers", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AluMembers", "DOB", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AluMembers", "Name", c => c.String());
        }
    }
}
