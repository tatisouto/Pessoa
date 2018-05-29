using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.MVC.ViewModel;

namespace Projeto.Agenda.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            ConfigureMappings();
        }


        private void ConfigureMappings()
        {
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            //CreateMap<Contact, ContactViewModel>().ReverseMap();
            //CreateMap<Address, AddressViewModel>().ReverseMap();
            //CreateMap<Phone, PhoneViewModel>().ReverseMap();
            //CreateMap<Classification, ClassificationViewModel>().ReverseMap();


        }

    }
}

