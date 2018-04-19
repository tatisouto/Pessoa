using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Agenda.Domain.Interfaces.Repositories;

namespace Projeto.Agenda.Domain.Services
{
    public class ContactService : ServiceBase<Contact>, IContactService
    {

        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository) : base(contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void AddContact(Contact contact)
        {
            _contactRepository.AddContact(contact);
        }
    }
}



