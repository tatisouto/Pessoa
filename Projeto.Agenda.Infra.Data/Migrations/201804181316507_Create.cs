namespace Projeto.Agenda.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StreetAddress = c.String(nullable: false, maxLength: 100, unicode: false),
                        PostalCode = c.String(nullable: false, maxLength: 10, unicode: false),
                        City = c.String(nullable: false, maxLength: 50, unicode: false),
                        State = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Company = c.String(nullable: false, maxLength: 50, unicode: false),
                        DtCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContactId = c.Guid(nullable: false),
                        ClassificationId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classification", t => t.ClassificationId)
                .ForeignKey("dbo.Contact", t => t.ContactId)
                .Index(t => t.ContactId)
                .Index(t => t.ClassificationId);
            
            CreateTable(
                "dbo.Classification",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "Id", "dbo.Contact");
            DropForeignKey("dbo.Phone", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Phone", "ClassificationId", "dbo.Classification");
            DropIndex("dbo.Phone", new[] { "ClassificationId" });
            DropIndex("dbo.Phone", new[] { "ContactId" });
            DropIndex("dbo.Address", new[] { "Id" });
            DropTable("dbo.Classification");
            DropTable("dbo.Phone");
            DropTable("dbo.Contact");
            DropTable("dbo.Address");
        }
    }
}
