using AutoMapper;
using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Agenda.MVC.ViewModel
{
    public class PessoaViewModel
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe número de Cpf.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe Email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe Data de nascimento.")]
        public DateTimeOffset DtNascimento { get; set; }

        public DateTimeOffset DtCreate { get; set; }

        public PessoaViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public static PessoaViewModel ToViewModel(Pessoa pessoa)
        {
            return Mapper.Map<PessoaViewModel>(pessoa);
        }
    }
}

