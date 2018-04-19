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
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository  addressRepository) : base(addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address GetAddressByIdContact(Guid id)
        {
           return  _addressRepository.GetAddressByIdContact(id);
        }
    }
}


