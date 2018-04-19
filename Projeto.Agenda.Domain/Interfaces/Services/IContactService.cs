using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Domain.Interfaces.Services
{
    public interface IContactService : IServiceBase<Contact>
    {
        void AddContact(Contact contact);
    }
}
