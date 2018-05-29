using AutoMapper;
using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Agenda.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }


        public DomainToViewModelMappingProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<PessoaViewModel, Pessoa>().ReverseMap();
            //CreateMap<ContactViewModel, Contact>().ReverseMap();
            //CreateMap<AddressViewModel, Address>().ReverseMap();
            //CreateMap<ClassificationViewModel, Classification>().ReverseMap();
            //CreateMap<PhoneViewModel, Phone>().ReverseMap();

        }


    }
}