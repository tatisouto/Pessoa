using Projeto.Agenda.Domain.Entities;
using System;

namespace Projeto.Agenda.Domain.Interfaces.Repositories
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Address GetAddressByIdContact(Guid id);
    }
}
