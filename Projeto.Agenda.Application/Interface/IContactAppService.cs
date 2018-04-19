using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Application.Interface
{
    public interface IContactAppService : IAppServiceBase<Contact>
    {
        void AddContact(Contact contact);
    }
}
