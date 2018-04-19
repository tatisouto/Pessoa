using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Infra.Data.EntityConfig
{
    public class PhoneConfiguration : EntityTypeConfiguration<Phone>
    {
        public PhoneConfiguration()
        {
            HasKey(x => x.Id)
            .Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();

            Property(p => p.Number)
                .HasColumnName("Number")
                .IsRequired();


            Property(p => p.ContactId)
             .HasColumnName("ContactId")
             .IsRequired();

            Property(p => p.ClassificationId)
           .HasColumnName("ClassificationId")
           .IsRequired();



            HasRequired(x => x.Contact)
            .WithMany(x => x.Phone)
            .HasForeignKey(c => c.ContactId);









        }
    }
}
