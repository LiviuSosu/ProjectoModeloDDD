[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjectDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjectDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjectDD.MVC.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using ProjectDDD.Application;
    using ProjectDDD.Application.Interfaces;
    using ProjectDDD.Domain.Interfaces;
    using ProjectDDD.Domain.Interfaces.Services;
    using ProjectDDD.Domain.Services;
    using ProjectDDD.Infrasructure.Repositories;
    using System;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
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

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind(typeof(IClienteAppService)).To(typeof(ClienteAppService));
            kernel.Bind(typeof(IProductAppService)).To(typeof(ProductAppService));

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind(typeof(IClientService)).To(typeof(ClienteService));
            kernel.Bind(typeof(IProdutoService)).To(typeof(ProductService));

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind(typeof(IClienteRepository)).To(typeof(ClienteRepository));
            kernel.Bind(typeof(IProdutoRepository)).To(typeof(ProdutoRepository));
        }
    }
}
