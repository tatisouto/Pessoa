namespace Projeto.Agenda.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cpf = c.String(maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        DtNascimento = c.DateTimeOffset(nullable: false, precision: 7),
                        DtCreate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoa");
        }
    }
}
