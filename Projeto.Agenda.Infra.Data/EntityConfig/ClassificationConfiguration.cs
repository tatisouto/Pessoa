using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Infra.Data.EntityConfig
{
    public class ClassificationConfiguration : EntityTypeConfiguration<Classification>
    {
        public ClassificationConfiguration()
        {
            HasKey(x => x.Id)
           .Property(x => x.Id)
           .HasColumnName("Id")
           .IsRequired();

            Property(p => p.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(30);

          
        }
    }
}
