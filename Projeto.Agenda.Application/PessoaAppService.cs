using Projeto.Agenda.Application.Interface;
using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Application
{
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;


        public PessoaAppService(IPessoaService pessoaService) : base(pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public Pessoa GetPessoaByCpf(string cpf)
        {
            return _pessoaService.GetPessoaByCpf(cpf);
        }
    }
}
