using Ninject.Modules;
using Projeto.Agenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Agenda.CrossCutting.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IContactRepository>().To<ContactRepository>();
        }

        

    }
}
