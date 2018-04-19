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
    public class PhoneService : ServiceBase<Phone>, IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository) : base(phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public ICollection<Phone> GetPhoneByIdContact(Guid id)
        {
            return _phoneRepository.GetPhoneByIdContact(id);
        }
    }
}

