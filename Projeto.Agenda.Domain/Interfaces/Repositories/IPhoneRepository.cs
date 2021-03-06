﻿using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Domain.Interfaces.Repositories
{
    public interface IPhoneRepository : IRepositoryBase<Phone>
    {
        ICollection<Phone> GetPhoneByIdContact(Guid id);
    }
}
