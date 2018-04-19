using System;
using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.Domain.Interfaces.Repositories;

namespace Projeto.Agenda.Infra.Data.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public void AddContact(Contact contact)
        {
            Db.Contacts.Add(contact);

        }
    }
}
