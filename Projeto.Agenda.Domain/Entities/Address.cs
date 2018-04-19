using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.Domain.Entities
{
    [Table("Address")]
    public class Address
    {
        public Guid Id { get; set; }        
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
      

        public virtual Contact Contact { get; set; }


    }
}
