using Projeto.Agenda.Domain.Entities;

namespace Projeto.Agenda.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Pessoa GetPessoaByCpf(string cpf);
    }
}
