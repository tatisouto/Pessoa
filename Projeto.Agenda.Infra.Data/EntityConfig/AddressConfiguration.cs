using Projeto.Agenda.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Agenda.Infra.Data.EntityConfig
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasKey(p => p.Id)
            .Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();

            Property(p => p.StreetAddress)
            .HasColumnName("StreetAddress")
            .IsRequired()
            .HasMaxLength(100);

            Property(p => p.PostalCode)
            .HasColumnName("PostalCode")
             .HasMaxLength(10)
            .IsRequired();

            Property(p => p.City)
            .HasColumnName("City")
            .IsRequired()
            .HasMaxLength(50);

            Property(p => p.State)
            .HasColumnName("State")
            .IsRequired()
            .HasMaxLength(30);

            HasRequired(p => p.Contact)
            .WithOptional(p => p.Address);







        }
    }
}
