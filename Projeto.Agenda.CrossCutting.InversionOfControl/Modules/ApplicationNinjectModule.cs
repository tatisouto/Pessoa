using Ninject.Modules;
using Projeto.Agenda.Application;
using Projeto.Agenda.Application.Interface;

namespace Projeto.Agenda.CrossCutting.InversionOfControl.Modules
{
    public  class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IContactAppService>().To<ContactAppService>();
           
        }
    }
}
