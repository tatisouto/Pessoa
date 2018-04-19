using AutoMapper;
using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Agenda.MVC.ViewModel
{
    public class ContactViewModel
    {
       
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public virtual AddressViewModel Address { get; set; }
        public virtual ICollection<PhoneViewModel> Phone { get; set; }
        public DateTime DtCreate { get; set; }


        public ContactViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public static ContactViewModel ToViewModel(Contact contact)
        {
            return Mapper.Map<ContactViewModel>(contact);
        }
    }
}


