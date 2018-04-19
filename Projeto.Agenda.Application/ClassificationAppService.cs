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
    public class ClassificationAppService : AppServiceBase<Classification>, IClassificationAppService
    {
        private readonly IClassificationService _classificationService;

        public ClassificationAppService(IClassificationService classificationService) : base(classificationService)
        {
            _classificationService = classificationService;
        }
    }
}


