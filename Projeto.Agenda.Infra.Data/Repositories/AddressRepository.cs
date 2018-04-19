using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Infra.Data.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public Address GetAddressByIdContact(Guid id)
        {
            return Db.Addresses.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
