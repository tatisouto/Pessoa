using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Infra.Data.EntityConfig
{
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            HasKey(p => p.Id)
            .Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();


            Property(p => p.FirstName)
            .IsRequired()
            .HasColumnName("FirstName")
            .HasMaxLength(30);

            Property(p => p.LastName)
            .HasColumnName("LastName")
            .IsRequired()
            .HasMaxLength(50);

            Property(p => p.Email)
            .HasColumnName("Email")
            .IsRequired()
            .HasMaxLength(50);

            Property(p => p.Company)
            .HasColumnName("Company")
           .IsRequired()
           .HasMaxLength(50);

            Property(p => p.DtCreate)
            .HasColumnName("DtCreate")
            .IsRequired();

            HasOptional(p => p.Address)
            .WithRequired(p => p.Contact);


            HasMany(p => p.Phone)
            .WithRequired(p => p.Contact)
            .HasForeignKey(p => p.ContactId);



        }
    }
}
