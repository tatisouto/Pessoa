using Projeto.Agenda.Domain.Entities;
using System;

namespace Projeto.Agenda.Application.Interface
{
    public interface IAddressAppService : IAppServiceBase<Address>
    {
        Address GetAddressByIdContact(Guid id);
    }
}
