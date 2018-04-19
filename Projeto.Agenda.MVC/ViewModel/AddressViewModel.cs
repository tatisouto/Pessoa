using AutoMapper;
using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Agenda.MVC.ViewModel
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
               
        public virtual ContactViewModel Contact { get; set; }
    

        public static AddressViewModel ToViewModel(Address address)
        {
            return Mapper.Map<AddressViewModel>(address);
        }

    }
}


