using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Infra.Data.EntityConfig
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            HasKey(p => p.Id)
            .Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();

            Property(p => p.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasMaxLength(50);

            Property(p => p.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasMaxLength(30);
            
            Property(p => p.DtNascimento)
            .HasColumnName("DtNascimento")
            .IsRequired();

            Property(p => p.DtCreate)
            .HasColumnName("DtCreate")
            .IsRequired();
        }
    }
}
