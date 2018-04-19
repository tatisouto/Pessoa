using Projeto.Agenda.Application.Interface;
using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Agenda.Domain.Interfaces.Services;

namespace Projeto.Agenda.Application
{
    public class ContactAppService : AppServiceBase<Contact>, IContactAppService
    {
        private readonly IContactService _contactService;

        public ContactAppService(IContactService contactService) : base(contactService)
        {
            _contactService = contactService;
        }

        public void AddContact(Contact contact)
        {
            _contactService.AddContact(contact);

        }
    }
}
