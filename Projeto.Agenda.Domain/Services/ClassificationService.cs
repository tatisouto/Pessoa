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
    public class ClassificationService : ServiceBase<Classification>, IClassificationService
    {
        private readonly IClassificationRepository _classificationRepository;

        public ClassificationService(IClassificationRepository classificationRepository) : base(classificationRepository)
        {
            _classificationRepository = classificationRepository;
        }
    }
}
