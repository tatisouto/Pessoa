using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projeto.Agenda.Domain.Entities
{
    [Table("Contact")]
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Phone> Phone { get; set; }
        public DateTime DtCreate { get; set; }

     

        public Contact()
        {         
            Phone = new HashSet<Phone>();
        }
    }

 
}
