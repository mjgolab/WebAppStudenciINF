namespace WebAppStudenciINF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        SID = c.String(nullable: false),
                        Course = c.String(nullable: false),
                        GroupName = c.String(nullable: false),
                        Specialty = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
