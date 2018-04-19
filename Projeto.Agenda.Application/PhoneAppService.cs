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
    public class PhoneAppService : AppServiceBase<Phone>, IPhoneAppService
    {
        private readonly IPhoneService _phoneService;

        public PhoneAppService(IPhoneService phoneService) : base(phoneService)
        {
            _phoneService = phoneService;
        }

        public ICollection<Phone> GetPhoneByIdContact(Guid id)
        {
            return _phoneService.GetPhoneByIdContact(id);
        }
    }
}
