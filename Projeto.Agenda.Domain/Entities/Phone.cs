using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Agenda.Domain.Entities
{
    [Table("Phone")]
    public class Phone
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public Guid ClassificationId { get; set; }
        public int Number { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Classification Classification { get; set; }


    }
}
