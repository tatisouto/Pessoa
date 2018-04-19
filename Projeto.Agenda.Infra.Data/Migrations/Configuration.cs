namespace Projeto.Agenda.Infra.Data.Migrations
{
    using Projeto.Agenda.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto.Agenda.Infra.Data.Context.ProjetoAgendaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Projeto.Agenda.Infra.Data.Context.ProjetoAgendaContext context)
        {
            var classification = new List<Classification>
            {
               new Classification { Id = Guid.NewGuid(), Description = "Casa" },
                new Classification { Id = Guid.NewGuid(), Description = "Trabalho" },
                new Classification { Id = Guid.NewGuid(), Description = "Celular" },
                new Classification { Id = Guid.NewGuid(), Description = "Principal" },
                new Classification { Id = Guid.NewGuid(),  Description = "Outros" },
                new Classification { Id = Guid.NewGuid(), Description = "Iphone" }
            };

            context.SaveChanges();
        }
    }
}
