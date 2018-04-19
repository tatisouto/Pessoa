using System;
using System.Collections.Generic;
using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.Domain.Interfaces.Repositories;
using System.Linq;

namespace Projeto.Agenda.Infra.Data.Repositories
{
    public class PhoneRepository : RepositoryBase<Phone>, IPhoneRepository
    {
        public ICollection<Phone> GetPhoneByIdContact(Guid id)
        {
            var result =  Db.Phones.Where(p => p.ContactId == id);

            return new HashSet<Phone>(result);
        }
    }
}
