using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Projeto.Agenda.MVC.ViewModel
{
    public class PhoneViewModel
    {

        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public Guid ClassificationId { get; set; }
        public int Number { get; set; }
        public virtual ContactViewModel Contact { get; set; }
        public virtual ClassificationViewModel Classification { get; set; }


        public PhoneViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public static PhoneViewModel ToViewModel(Phone phone)
        {
            return Mapper.Map<PhoneViewModel>(phone);
        }
    }



}
