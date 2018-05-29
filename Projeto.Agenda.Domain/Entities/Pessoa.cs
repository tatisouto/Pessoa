using System;

namespace Projeto.Agenda.Domain.Entities
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DtNascimento { get; set; }
        public DateTimeOffset DtCreate { get; set; }
    }
}
