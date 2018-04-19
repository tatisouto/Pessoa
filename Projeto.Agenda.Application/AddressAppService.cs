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
    public class AddressAppService : AppServiceBase<Address>, IAddressAppService
    {
        private readonly IAddressService _addressService;

        public AddressAppService(IAddressService addressService) : base(addressService)
        {
            _addressService = addressService;
        }

        public Address GetAddressByIdContact(Guid id)
        {
            return _addressService.GetAddressByIdContact(id);
        }

        
    }
}



