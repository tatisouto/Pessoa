using AutoMapper;
using Projeto.Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Agenda.MVC.ViewModel
{
    public class ClassificationViewModel
    {       
        public Guid Id { get; set; }
        public string Description { get; set; }
        

        public static ClassificationViewModel ToViewModel(Classification classification)
        {
            return Mapper.Map<ClassificationViewModel>(classification);
        }
    }
}


