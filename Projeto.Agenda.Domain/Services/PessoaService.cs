using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.Domain.Interfaces.Repositories;
using Projeto.Agenda.Domain.Interfaces.Services;

namespace Projeto.Agenda.Domain.Services
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;


        public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Pessoa GetPessoaByCpf(string cpf)
        {
           return  _pessoaRepository.GetPessoaByCpf(cpf);
        }
    }
}
