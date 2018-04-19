using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Projeto.Agenda.Application.Interface;
using Projeto.Agenda.Application;
using Projeto.Agenda.Domain.Interfaces.Services;
using Projeto.Agenda.Domain.Services;
using Projeto.Agenda.Domain.Interfaces.Repositories;
using Projeto.Agenda.Infra.Data.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Projeto.Agenda.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Projeto.Agenda.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Projeto.Agenda.MVC.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IContactAppService>().To<ContactAppService>();
            kernel.Bind<IAddressAppService>().To<AddressAppService>();
            kernel.Bind<IClassificationAppService>().To<ClassificationAppService>();
            kernel.Bind<IPhoneAppService>().To<PhoneAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IContactService>().To<ContactService>();
            kernel.Bind<IAddressService>().To<AddressService>();
            kernel.Bind<IClassificationService>().To<ClassificationService>();
            kernel.Bind<IPhoneService>().To<PhoneService>();


            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IContactRepository>().To<ContactRepository>();
            kernel.Bind<IAddressRepository>().To<AddressRepository>();
            kernel.Bind<IClassificationRepository>().To<ClassificationRepository>();
            kernel.Bind<IPhoneRepository>().To<PhoneRepository>();

        }


    }
}