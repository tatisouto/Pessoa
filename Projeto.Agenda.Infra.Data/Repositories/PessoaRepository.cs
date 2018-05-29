using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Infra.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public Pessoa GetPessoaByCpf(string cpf)
        {
            return Db.Pessoas.Where(x => x.Cpf == cpf).FirstOrDefault();
        }
    }
}
