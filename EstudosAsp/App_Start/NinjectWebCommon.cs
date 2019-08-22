[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EstudosAsp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EstudosAsp.App_Start.NinjectWebCommon), "Stop")]

namespace EstudosAsp.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using EstudosAsp.Contexts;
    using EstudosAsp.DAO;
    using EstudosAsp.Servico;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common; 
 

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

                //Adicionado por conta do tipo de controlador - ApiController - foi adicionado o pacote Ninject.WebApi.DependencyResolver
                GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);

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
            //kernel.Bind<IServico<Nivel>>().To<NivelServico>().Named("nivelServico");
            //SERVICOS
            kernel.Bind<NivelServico>().To<NivelServico>();
            kernel.Bind<ProdutoServico>().To<ProdutoServico>();

            //DAOs
            kernel.Bind(typeof(IRepositorio<>)).To(typeof(Repositorio<>));
            kernel.Bind<EstudoContext>().To<EstudoContext>();
            kernel.Bind<NivelDAO>().To<NivelDAO>();

        }        
    }
}
