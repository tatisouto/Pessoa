using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Projeto.Agenda.Infra.Data.Context
{
    public class ProjetoCadastroContext : DbContext
    {
        public ProjetoCadastroContext()
            : base("BDPessoa")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<ProjetoCadastroContext>(null);
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Phone> Phones { get; set; }
        //public DbSet<Classification> Classification { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PessoaConfiguration());
            //modelBuilder.Configurations.Add(new AddressConfiguration());
            //modelBuilder.Configurations.Add(new ClassificationConfiguration());
            //modelBuilder.Configurations.Add(new ContactConfiguration());
            //modelBuilder.Configurations.Add(new PhoneConfiguration());


        }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DtCreate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DtCreate").CurrentValue = DateTimeOffset.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DtCreate").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
